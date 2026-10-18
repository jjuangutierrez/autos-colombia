using AutosColombia.BusinessLogic;
using AutosColombia.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<RegistroRepository>();
builder.Services.AddSingleton<AccesoService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/estado", (AccesoService servicio) => new {
    libres = servicio.ContarDisponibles(),
    ocupadas = servicio.ContarOcupadas(),
    activos = servicio.ObtenerVehiculosActivos()
});

app.MapPost("/api/entrada", (EntradaRequest req, AccesoService servicio) => {
    var resultado = servicio.RegistrarEntrada(req.Placa, req.Tipo);
    return Results.Ok(new { mensaje = resultado, exito = resultado.StartsWith("Éxito") });
});

app.MapPost("/api/salida", (SalidaRequest req, AccesoService servicio) => {
    var resultado = servicio.RegistrarSalida(req.Placa);
    return Results.Ok(new { mensaje = resultado, exito = resultado.StartsWith("Éxito") });
});

app.Run();

public record EntradaRequest(string Placa, string Tipo);
public record SalidaRequest(string Placa);