using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Context;
using PruebaTecnica.Interfaces;
using PruebaTecnica.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MiPolitica",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddDbContext<PruebaTecnicaContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProducto, ProductoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MiPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
