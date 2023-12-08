using Livraria.Domain.Interfaces;
using Livraria.Domain.Servicos;
using Livraria.Infra.Repository;
using Livraria.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string server = "localhost";
string database = "livraria";
string uid = "your_mysql_user";
string password = "your_mysql_root_password";

string connectionString = $"Server={server};Database={database};User ID={uid};Password={password};";

builder.Services.AddDbContext<LivrariaDbContext>(options =>
          options.UseMySQL(connectionString));

builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<ICompraRepository, CompraRepository>();
builder.Services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();

builder.Services.AddScoped<ILivroServico, LivroServico>();
builder.Services.AddScoped<ICompraServico, CompraServico>();
builder.Services.AddScoped<ICarrinhoServico, CarrinhoServico>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
