using Microsoft.EntityFrameworkCore;
using C_Projeto3.Infra.Data;
using projeto3.api.Models.Repository.Interfaces;
using projeto3.api.Models.Repository;


var builder = WebApplication.CreateBuilder(args);

var connectString = builder.Configuration.GetConnectionString("Defaultconnection");

var serverVersion = new MySqlServerVersion(new Version(8, 0, 23));

//Banco
builder.Services.AddDbContext<AppDbContext>(optionsAction: options => options
.UseMySql(connectString, serverVersion)
.LogTo(Console.WriteLine, LogLevel.Information)
.EnableSensitiveDataLogging()
.EnableDetailedErrors());

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
options.AddPolicy("AllowAll", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader())
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
