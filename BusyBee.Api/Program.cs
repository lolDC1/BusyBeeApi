using System.Text.Json;
using System.Text.Json.Serialization;
using BusyBee.Api.Authorization;
using BusyBee.Api.Controllers.CrudBase;
using BusyBee.Api.Middleware;
using BusyBee.Api.Services;
using BusyBee.Core.Configurations;
using BusyBee.Core.Exceptions.Factories;
using BusyBee.Core.Interfaces;
using BusyBee.Core.Interfaces.ExceptionFactories;
using BusyBee.Core.Interfaces.Repositories;
using BusyBee.Core.Interfaces.Services;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Services;
using BusyBee.Core.Services.Domain;
using BusyBee.Core.Services.Domain.CrudBase;
using BusyBee.Core.Validators.CategoryOfTasks;
using BusyBee.Persistence;
using BusyBee.Persistence.Design;
using BusyBee.Persistence.Repositories;
using BusyBee.Persistence.Repositories.CrudBase;
using BusyBee.Storage;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

        options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
    });

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(o => o.UseNpgsql(connectionString,
    optionsBuilder =>
    {
        optionsBuilder.MigrationsAssembly(typeof(DatabaseContextFactory).Assembly.GetName().Name);
        optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    })
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddValidatorsFromAssemblyContaining<CategoryOfTasksCreateCommandValidator>();

builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration, "AzureAdB2C");
builder.Services.AddAuthorization();
builder.Services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();

builder.Services.AddScoped<ICategoryOfCategoriesRepository, CategoryOfCategoriesRepository>();
builder.Services.AddScoped<ICategoryOfTasksRepository, CategoryOfTasksRepository>();
builder.Services.AddScoped<IDataTemplateRepository, DataTemplateRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserPortfolioFileRepository, UserPortfolioFileRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<ICategoryOfCategoriesService, CategoryOfCategoriesService>();
builder.Services.AddScoped<ICategoryOfTasksService, CategoryOfTasksService>();
builder.Services.AddScoped<IDataTemplateService, DataTemplateService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork<DatabaseContext>>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IEntityAuditService, EntityAuditService>();
builder.Services.AddScoped<IDateTimeService, DateTimeService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();

builder.Services.AddTransient<IExceptionFactory, ExceptionFactory>();

builder.Services.AddTransient<ControllerCommonDependencies>();
builder.Services.AddTransient<RepositoryCommonDependencies>();
builder.Services.AddTransient<EntityCrudServiceCommonDependencies>();

builder.Services.Configure<LocalStorageOptions>(builder.Configuration.GetSection("LocalStorage"));

if (builder.Environment.IsDevelopment())
    builder.Services.AddCors(options => options.AddDefaultPolicy(b => { b.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin(); }));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var b2cUrl =
    $"{builder.Configuration["AzureAdB2C:Instance"]}/{builder.Configuration["AzureAdB2C:Domain"]}/{builder.Configuration["AzureAdB2C:SignUpSignInPolicyId"]}/oauth2/v2.0";
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Busy Bee API", Version = "v1" });
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "OAuth2.0 Auth Code with PKCE",
        Name = "oauth2",
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri($"{b2cUrl}/authorize"),
                TokenUrl = new Uri($"{b2cUrl}/token"),
                Scopes = new Dictionary<string, string>
                {
                    { builder.Configuration["AzureAdB2C:OpenApiScopeApi"]!, "Access the api as the signed-in user" }
                }
            }
        }
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
            },
            new[] { builder.Configuration["AzureAdB2C:OpenApiScopeApi"]! }
        }
    });
});

var app = builder.Build();

using var scope = app.Services.CreateScope();
await scope.ServiceProvider.GetRequiredService<DatabaseContext>().Database.MigrateAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Busy Bee API v1");
        c.OAuthClientId(builder.Configuration["AzureAdB2C:OpenApiClientId"]!);
        c.OAuthUsePkce();
        c.OAuthScopeSeparator(" ");
    });
    app.UseCors();
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();