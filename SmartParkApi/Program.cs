using Scalar;
using Scalar.AspNetCore;
using SmartParkApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registras tu servicio como Scoped
builder.Services.AddScoped<EspacioService>();
builder.Services.AddScoped<NivelService>();
builder.Services.AddScoped<RegistraEntradaService>();
builder.Services.AddScoped<RegistraSalidaService>();
builder.Services.AddScoped<TarifaService>();
builder.Services.AddScoped<TransaccionService>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
