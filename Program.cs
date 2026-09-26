using Microsoft.EntityFrameworkCore;
using SV_backend.Application.Interfaces;
using SV_backend.Application.Services;
using SV_backend.Application.Mappings;
using SV_backend.Domain.Interfaces;
using SV_backend.Infrastructure.Data.Context;
using SV_backend.Infrastructure.Repositories;
using SV_backend.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SvDbContext>(options =>
    options.UseSqlServer(connectionString)
);

var redisConnectionString = builder.Configuration.GetConnectionString("Redis");

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = redisConnectionString;
    options.InstanceName = "RedisCacheInstance";
});

// Registra o repositório no container de Injeção de Dependência do .NET
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ICarrinhoService, RedisCarrinhoService>();
// Registra o serviço de produto
builder.Services.AddScoped<IProdutoService, ProdutoService>();
// Registra repositório de categoria
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

// Registra o serviço de AutoMapper
builder.Services.AddAutoMapper(cfg => 
{
    cfg.AddProfile<ProdutoProfile>();
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
