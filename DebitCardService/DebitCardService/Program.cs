using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Validators;
using DebitCardService.ApplicationServices.Components.ExchangeRate;
using DebitCardService.ApplicationServices.Mappings;
using DebitCardService.DataAccess;
using DebitCardService.DataAccess.CQRS;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders().SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddFluentValidationAutoValidation().AddValidatorsFromAssemblyContaining<AddUserRequestValidator>();
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddTransient<IExchangeRatesConnector, ExchangeRatesConnector>();
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
builder.Services.AddAutoMapper(typeof(UsersProfile).Assembly);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
