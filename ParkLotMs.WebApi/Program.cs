using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ParkLotMs.Application;
using ParkLotMs.Application.Interfaces;
using ParkLotMs.DataAccess.DbAccess;
using ParkLotMs.Infrastructure;
using ParkLotMs.Infrastructure.Authentication;
using ParkLotMs.Persistence;
using ParkLotMs.WebApi.OptionsSetup;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDatabasePostgreSQL(builder.Configuration, "DefaultConnection");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureOptions<JwtOptionSetup>();
//builder.Services.Configure<JwtOptions>(options => builder.Configuration.Bind("Jwt",options));
builder.Services.ConfigureOptions<JwtBearerSetup>();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfraServices(builder.Configuration);
//builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        name: "v1",
        info: new OpenApiInfo
        {
            Title = $"API Parking Lot Management System",
            Version = "v1",
            Description = "Api Project created by RadyaLabs",
        });

    c.AddSecurityDefinition(
        name: "Bearer",
        securityScheme: new OpenApiSecurityScheme
        {
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Description = "Input your Bearer token in this format - Bearer {your token here} to access this API",
        });

    //c.OperationFilter<SecurityRequirementsOperationFilter>();

    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[]{}
                }
        });

});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();
builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder().AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseDeveloperExceptionPage();
app.UseOpenApi();

app.MapControllers();

app.Run();
