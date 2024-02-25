using DebitCardService.ApplicationServices.Components.HashPassword;
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
    private readonly IPasswordHasher _passwordHasher;

    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IQueryExecutor queryExecutor,
        IPasswordHasher passwordHasher)
        : base(options, logger, encoder, clock)
    {
        _queryExecutor = queryExecutor;
        _passwordHasher = passwordHasher;
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
            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authenticationHeaderValue.Parameter!);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
            var login = credentials[0];
            var password = credentials[1];
            var query = new GetUsersQuery
            {
                Login = login
            };
            users = await _queryExecutor.Execute(query);

            //var hashed = _passwordHasher.CreateHashPassword(password);
            var hashedPassword = _passwordHasher.CheckHashPassword(password, users[0].Password!);
            
            if (users == null || users[0].Password != hashedPassword)
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }
        }
        catch (Exception)
        {
            return AuthenticateResult.Fail("Invalid Authorization Header");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, users[0].Id.ToString()),
            new Claim(ClaimTypes.Name, users[0].Login!),
            new Claim(ClaimTypes.Role, users[0].AccessLevel.ToString())
        };

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);
        return AuthenticateResult.Success(ticket);
    }
}
