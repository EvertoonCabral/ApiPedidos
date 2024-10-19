using ApiControlePedidos.Application.Services;
using ApiControlePedidos.Infrastructure;
using ApiControlePedidos.Domain.Repositories;
using ApiControlePedidos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using ControlePedidos.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adicionando servi�os ao cont�iner.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrando o ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Registrando os reposit�rios
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

// Registrando o PedidoService
builder.Services.AddScoped<PedidoService>();

var app = builder.Build();

// Configurando o pipeline de requisi��o HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
