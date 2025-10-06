using DevHabit.Api.Database;
using DevHabit.Api.Middleware;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json.Serialization;

namespace DevHabit.Api;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddControllers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            })
            .AddXmlSerializerFormatters();
        builder.Services.AddOpenApi();
        return builder;
    }

    public static WebApplicationBuilder AddErrorHandling(this WebApplicationBuilder builder)
    {
        // Fluenty Validator
        builder.Services.AddValidatorsFromAssemblyContaining<Program>();
        // Обработка ошибок сервера с выдачей в нужном формате

        builder.Services.AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
            };
        });
        // Обработка валидации и вывод в стандартном виде
        builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
        // Пользовательская обработка исключений
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        return builder;
    }

    public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("Database"),
                    npgsqlOptions =>
                        npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Application))
                .UseSnakeCaseNamingConvention());
        return builder;
    }
}
