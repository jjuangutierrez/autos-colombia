namespace AutosColombia.Models;

public class RegistroAcceso
{
    public int IdRegistro { get; set; }
    public DateTime FechaEntrada { get; set; }
    public DateTime? FechaSalida { get; set; }
    public string PlacaVehiculo { get; set; } = string.Empty;
    public string TipoVehiculo { get; set; } = string.Empty;
    public int IdCelda { get; set; }
    public int IdUsuario { get; set; }
    public string Estado { get; set; } = "Activo";
}