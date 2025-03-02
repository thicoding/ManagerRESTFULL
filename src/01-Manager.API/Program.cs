using _04_Manager.Data.Context;
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
