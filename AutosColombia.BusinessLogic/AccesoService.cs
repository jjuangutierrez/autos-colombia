using AutosColombia.Data;
using AutosColombia.Models;

namespace AutosColombia.BusinessLogic;

public class AccesoService
{
    private readonly RegistroRepository _repo;

    public AccesoService(RegistroRepository repo)
    {
        _repo = repo;
    }

    public string RegistrarEntrada(string placa, string tipo)
    {
        if (string.IsNullOrWhiteSpace(placa))
            return "Debe ingresar una placa válida.";

        placa = placa.Trim().ToUpper();

        bool yaEstaDentro = _repo.Registros.Any(r => r.PlacaVehiculo == placa && r.Estado == "Activo");
        if (yaEstaDentro)
            return $"El vehículo con placa {placa} ya se encuentra dentro del parqueadero.";

        var celdaDisponible = _repo.Celdas.FirstOrDefault(c => c.Estado == "Disponible");
        if (celdaDisponible == null)
            return "No hay celdas disponibles en este momento. Parqueadero lleno.";

        celdaDisponible.Estado = "Ocupada";

        var nuevoRegistro = new RegistroAcceso
        {
            IdRegistro = _repo.Registros.Count + 1,
            PlacaVehiculo = placa,
            TipoVehiculo = tipo,
            IdCelda = celdaDisponible.IdCelda,
            IdUsuario = 1,
            FechaEntrada = DateTime.Now,
            Estado = "Activo"
        };

        _repo.Registros.Add(nuevoRegistro);

        return $"Éxito: Vehículo {placa} ingresado en la Celda #{celdaDisponible.Numero}.";
    }

    public string RegistrarSalida(string placa)
    {
        if (string.IsNullOrWhiteSpace(placa))
            return "Debe ingresar una placa.";

        placa = placa.Trim().ToUpper();

        var registro = _repo.Registros.FirstOrDefault(r => r.PlacaVehiculo == placa && r.Estado == "Activo");
        if (registro == null)
            return $"No se encontró ningún vehículo activo con la placa {placa}.";

        registro.FechaSalida = DateTime.Now;
        registro.Estado = "Finalizado";

        var celda = _repo.Celdas.FirstOrDefault(c => c.IdCelda == registro.IdCelda);
        if (celda != null)
        {
            celda.Estado = "Disponible";
        }

        return $"Éxito: Salida registrada para {placa}. Celda #{celda?.Numero} liberada.";
    }

    public List<RegistroAcceso> ObtenerVehiculosActivos() =>
        _repo.Registros.Where(r => r.Estado == "Activo").ToList();

    public int ContarDisponibles() => _repo.Celdas.Count(c => c.Estado == "Disponible");
    public int ContarOcupadas() => _repo.Celdas.Count(c => c.Estado == "Ocupada");
}