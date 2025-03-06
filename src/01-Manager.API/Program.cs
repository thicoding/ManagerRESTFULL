using _02_Manager.Data.Repository;
using _02_Manager.Domain.Validators;
using _02_Manager.Services;
using _04_Manager.Data.Context;
using _04_Manager.Data.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext para usar MySQL
builder.Services.AddDbContext<MenagerContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("ProdutoConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ProdutoConnection"))
    ));

// Adicionar os serviços da API
builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

// Configuração do Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapeia os controladores da API
app.MapControllers();

app.Run();
