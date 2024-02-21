using DebitCardService.DataAccess.CQRS;
using DebitCardService.DataAccess.CQRS.Queries;
using DebitCardService.DataAccess.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace DebitCardService.Authentication;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IQueryExecutor _queryExecutor;

    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IQueryExecutor queryExecutor)
        : base(options, logger, encoder, clock)
    {
        _queryExecutor = queryExecutor;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var endpoint = Context.GetEndpoint();
        if (endpoint?.Metadata.GetMetadata<IAllowAnonymous>() != null)
        {
            return AuthenticateResult.NoResult();
        }

        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.Fail("Missing Authorization Header");
        }

        List<User> users;
        try
        {
            var authenticationHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authenticationHeader.Parameter!);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' } , 2);
            var login = credentials[0];
            var password = credentials[1];
            var query = new GetUsersQuery()
            {
                Login = login,
            };
            users = await _queryExecutor.Execute(query);

            if(users == null || users[0].Password != password)
            {
                return AuthenticateResult.Fail("Invalid Autorization Header");
            }
        }
        catch (Exception)
        {
            return AuthenticateResult.Fail("Invalid Autorization Header");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, users[0].Id.ToString()),
            new Claim(ClaimTypes.Name, users[0].Login!)
        };

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);
        return AuthenticateResult.Success(ticket);
    }
}