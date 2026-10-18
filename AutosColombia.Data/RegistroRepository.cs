using AutosColombia.Models;

namespace AutosColombia.Data;

public class RegistroRepository
{
    public List<Celda> Celdas { get; set; } = new();
    public List<RegistroAcceso> Registros { get; set; } = new();
    public List<Vehiculo> Vehiculos { get; set; } = new();

    public RegistroRepository()
    {
        for (int i = 1; i <= 10; i++)
        {
            Celdas.Add(new Celda
            {
                IdCelda = i,
                Numero = i,
                Tipo = "Automóvil",
                Estado = "Disponible"
            });
        }
    }
}