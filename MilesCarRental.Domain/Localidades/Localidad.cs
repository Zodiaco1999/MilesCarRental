using MilesCarRental.Domain.Abstractions;
using MilesCarRental.Domain.Vehiculos;

namespace MilesCarRental.Domain.Localidades;

public sealed class Localidad : Entity
{
    public string Nombre { get; private set; }
    public Direccion Direccion { get; private set; }

    private Localidad() { }

    public Localidad(Guid id, string nombre, Direccion direccion) : base(id)
    {
        Nombre = nombre;
        Direccion = direccion;
    }
}
