using ParkSmartRD.Components;
using SmartParkApi.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar servicios para Blazor Server
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. Registrar el HttpClient apuntando a tu API y tu Servicio de API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7003") });
builder.Services.AddScoped<SmartParkApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// 3. Mapear componentes usando estrictamente el modo Interactive Server
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();