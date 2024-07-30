using System.Reflection;
using Lab4_Part2.Configurations;
using Lab4_Part2.Models;
using Lab4_Part2.Services;
using Lab4_Part2.Services.Absractions;
using Lab4_Part2.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(Program)));


// Add services to the container.
builder.Services.AddDbContext<UniversityDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Host=localhost:5434;Database=postgres;Username=root;Password=mysecretpassword")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSwaggerServices();
builder.Services.AddAuthenticationServices(builder.Configuration);

var jwtSettings = new JwtSettings();
builder.Configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);
builder.Services.AddSingleton(jwtSettings);


builder.Services.AddScoped<IKeycloakService, KeycloakService>();

builder.Services.AddHttpClient();

string fileStorageConnectionString = builder.Configuration.GetConnectionString("AzureBlobStorage");
builder.Services.AddSingleton<IFileStorageService>(new AzureBlobStorageService(fileStorageConnectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthenticationServices();

app.MapControllers();

app.Run();
