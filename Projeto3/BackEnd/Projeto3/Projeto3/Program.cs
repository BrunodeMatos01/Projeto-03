using Microsoft.EntityFrameworkCore;
using C_Projeto3.Infra.Data;
using C_Projeto3.Model.Repository;
using C_Projeto3.Model.Repository.Interfaces;
using projeto3.api.Models.Repository;
using projeto3.api.Models.Repository.Interfaces;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Configurar versão do servidor MySQL
var serverVersion = new MySqlServerVersion(new Version(8, 0, 23));

// Obter string de conexão do appsettings.json
var projeto3ConnectionString = builder.Configuration.GetConnectionString("Projeto3Connection");

// Configurar DbContext com a string de conexão única
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(projeto3ConnectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Registrar todos os repositórios
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IRelatorioRepository, RelatorioRepository>(); 

// Adicionar serviços MVC e Swagger
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS (liberando tudo neste exemplo)
builder.Services.AddCors(options =>
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// Criar app
var app = builder.Build();

// Configurar pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
