using APICatalogo.Context;
<<<<<<< HEAD
using APICatalogo.Extensions;
using APICatalogo.Filters;
using APICatalogo.Logging;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
=======
using Microsoft.EntityFrameworkCore;
>>>>>>> 79843e2aff15604942b57c8b83ebb6416177ddb8

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
<<<<<<< HEAD
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ApiExceptionFilter));
})
    .AddJsonOptions(options =>
    {
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;// Evita o erro de loop infinito na serialização JSON
});

=======
builder.Services.AddControllers();
>>>>>>> 79843e2aff15604942b57c8b83ebb6416177ddb8
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

<<<<<<< HEAD
var valor1 = builder.Configuration["chave1"];
var valor2 = builder.Configuration["secao1:chave2"];

=======
>>>>>>> 79843e2aff15604942b57c8b83ebb6416177ddb8
builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseMySql(mySqlConnection,
                    ServerVersion.AutoDetect(mySqlConnection)));

<<<<<<< HEAD
builder.Services.AddScoped<ApiLoggingFilter>();

builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    LogLevel = LogLevel.Information
}));   

=======
>>>>>>> 79843e2aff15604942b57c8b83ebb6416177ddb8
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
<<<<<<< HEAD
    app.ConfigureExceptionHandler();
=======
>>>>>>> 79843e2aff15604942b57c8b83ebb6416177ddb8
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
