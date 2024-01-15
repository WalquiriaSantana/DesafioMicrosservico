using Livraria.Domain.Interfaces;
using Livraria.Domain.Servicos;
using Livraria.Infra.Repository;
using Livraria.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = "server=localhost;user id=your_mysql_user;password=your_mysql_password;database=livraria";
builder.Services.AddDbContext<LivrariaDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<ICompraRepository, CompraRepository>();
builder.Services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();

builder.Services.AddScoped<ILivroServico, LivroServico>();
builder.Services.AddScoped<ICompraServico, CompraServico>();
builder.Services.AddScoped<ICarrinhoServico, CarrinhoServico>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
