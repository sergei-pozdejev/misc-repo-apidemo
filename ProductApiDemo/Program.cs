using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProductApiDemo.Data;
using ProductApiDemo.Data.Base;
using ProductApiDemo.Data.Interfaces;
using ProductApiDemo.Middleware;
using ProductApiDemo.Models;
using ProductApiDemo.Services;
using ProductApiDemo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
//Loggers

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product API demo", Version = "v1" });
    c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "ProductApiDemo.xml"));
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ProductDbContext>(x => x.UseSqlServer(connectionString));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
