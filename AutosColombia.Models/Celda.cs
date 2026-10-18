namespace AutosColombia.Models;

public class Celda
{
    public int IdCelda { get; set; }
    public int Numero { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public string Estado { get; set; } = "Disponible";
}