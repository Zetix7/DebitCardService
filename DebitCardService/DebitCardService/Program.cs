using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Validators;
using DebitCardService.ApplicationServices.Components.ExchangeRate;
using DebitCardService.ApplicationServices.Components.HashPassword;
using DebitCardService.ApplicationServices.Mappings;
using DebitCardService.Authentication;
using DebitCardService.DataAccess;
using DebitCardService.DataAccess.CQRS;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders().SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddFluentValidationAutoValidation().AddValidatorsFromAssemblyContaining<AddUserRequestValidator>();
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IExchangeRatesConnector, ExchangeRatesConnector>();
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
builder.Services.AddAutoMapper(typeof(UsersProfile).Assembly);
builder.Services.AddDbContext<DebitCardServiceStorageContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DebitCardServiceDatabaseConnection")));
builder.Services.AddMediatR(typeof(ResponseBase<>));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API DebitCardService v1");
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
