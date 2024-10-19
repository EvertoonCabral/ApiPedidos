using ApiControlePedidos.Application.Services;
using ApiControlePedidos.Infrastructure;
using ApiControlePedidos.Domain.Repositories;
using ApiControlePedidos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using ControlePedidos.Infrastructure.Repositories;
using ControlePedidos.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionando serviços ao contêiner.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrando o ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Registrando os repositórios
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

// Registrando o services
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<ProdutoService>(); 


var app = builder.Build();

// Configurando o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
