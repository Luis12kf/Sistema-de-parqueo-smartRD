using System.Net.Http.Json;
using SmartParkApi.Models;

namespace SmartParkApi.Services;

public class SmartParkApiService(HttpClient http)
{
    private readonly HttpClient _http = http;

    // ==========================================
    // 1. ESPACIOS (GET, PUT)
    // ==========================================
    public async Task<List<Espacio>?> ObtenerEspaciosAsync() =>
        await _http.GetFromJsonAsync<List<Espacio>>("api/espacios");

    public async Task<Espacio?> ObtenerEspacioPorIdAsync(int id) =>
        await _http.GetFromJsonAsync<Espacio>($"api/espacios/{id}");

    public async Task<bool> ActualizarEspacioAsync(int id, Espacio espacio)
    {
        var response = await _http.PutAsJsonAsync($"api/espacios/{id}", espacio);
        return response.IsSuccessStatusCode;
    }


    // ==========================================
    // 2. NIVELES (GET)
    // ==========================================
    public async Task<List<Nivel>?> ObtenerNivelesAsync() =>
        await _http.GetFromJsonAsync<List<Nivel>>("api/niveles");

    public async Task<Nivel?> ObtenerNivelPorIdAsync(int id) =>
        await _http.GetFromJsonAsync<Nivel>($"api/niveles/{id}");


    // ==========================================
    // 3. REGISTRO DE ENTRADAS (GET, POST, PUT)
    // ==========================================
    public async Task<List<RegistraEntrada>?> ObtenerEntradasAsync() =>
        await _http.GetFromJsonAsync<List<RegistraEntrada>>("api/registraentradas");

    public async Task<RegistraEntrada?> ObtenerEntradaPorIdAsync(int id) =>
        await _http.GetFromJsonAsync<RegistraEntrada>($"api/registraentradas/{id}");

    public async Task<HttpResponseMessage> CrearEntradaAsync(RegistraEntrada entrada) =>
        await _http.PostAsJsonAsync("api/registraentradas", entrada);

    public async Task<bool> ActualizarEstadoEntradaAsync(int id, bool estado)
    {
        var response = await _http.PutAsJsonAsync($"api/registraentradas/{id}/estado", estado);
        return response.IsSuccessStatusCode;
    }

    // ==========================================
    // 4. REGISTRO DE SALIDAS (GET, POST)
    // ==========================================
    public async Task<List<RegistraSalida>?> ObtenerSalidasAsync() =>
        await _http.GetFromJsonAsync<List<RegistraSalida>>("api/registrasalidas");

    public async Task<RegistraSalida?> ObtenerSalidaPorIdAsync(int id) =>
        await _http.GetFromJsonAsync<RegistraSalida>($"api/registrasalidas/{id}");

    public async Task<HttpResponseMessage> CrearSalidaAsync(RegistraSalida salida) =>
        await _http.PostAsJsonAsync("api/registrasalidas", salida);


    // ==========================================
    // 5. TARIFAS (GET, POST, PUT)
    // ==========================================
    public async Task<List<Tarifa>?> ObtenerTarifasAsync() =>
        await _http.GetFromJsonAsync<List<Tarifa>>("api/tarifas");

    public async Task<Tarifa?> ObtenerTarifaPorIdAsync(int id) =>
        await _http.GetFromJsonAsync<Tarifa>($"api/tarifas/{id}");

    public async Task<HttpResponseMessage> CrearTarifaAsync(Tarifa tarifa) =>
        await _http.PostAsJsonAsync("api/tarifas", tarifa);

    public async Task<bool> ActualizarTarifaAsync(int id, Tarifa tarifa)
    {
        var response = await _http.PutAsJsonAsync($"api/tarifas/{id}", tarifa);
        return response.IsSuccessStatusCode;
    }


    // ==========================================
    // 6. TRANSACCIONES (GET, POST, PUT)
    // ==========================================
    public async Task<List<Transaccion>?> ObtenerTransaccionesAsync() =>
        await _http.GetFromJsonAsync<List<Transaccion>>("api/transacciones");

    public async Task<Transaccion?> ObtenerTransaccionPorIdAsync(int id) =>
        await _http.GetFromJsonAsync<Transaccion>($"api/transacciones/{id}");

    public async Task<HttpResponseMessage> CrearTransaccionAsync(Transaccion transaccion) =>
        await _http.PostAsJsonAsync("api/transacciones", transaccion);

    public async Task<bool> ActualizarTransaccionAsync(int id, Transaccion transaccion)
    {
        var response = await _http.PutAsJsonAsync($"api/transacciones/{id}", transaccion);
        return response.IsSuccessStatusCode;
    }


    // ==========================================
    // 7. USUARIOS (GET)
    // ==========================================
    public async Task<List<Usuario>?> ObtenerUsuariosAsync() =>
        await _http.GetFromJsonAsync<List<Usuario>>("api/usuarios");

    public async Task<Usuario?> ObtenerUsuarioPorIdAsync(int id) =>
        await _http.GetFromJsonAsync<Usuario>($"api/usuarios/{id}");
}