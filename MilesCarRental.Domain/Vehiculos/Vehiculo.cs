using MilesCarRental.Domain.Abstractions;
using MilesCarRental.Domain.Localidades;
using MilesCarRental.Domain.Shared;

namespace MilesCarRental.Domain.Vehiculos;

public sealed class Vehiculo : Entity
{
    public Modelo Modelo { get; private set; }
    public Vin Vin { get; private set; }
    public Guid LocalidadId { get; private set; }
    public Moneda Precio { get; private set; }
    public Moneda Mantenimiento { get; private set; }
    public DateTime? FechaUltimaAlquiler { get; internal set; }
    public List<Accesorio> Accesorios { get; private set; } = [];

    private Vehiculo() { }

    public Vehiculo(
        Guid id,
        Modelo modelo,
        Vin vin,
        Guid localidadId,
        Moneda precio,
        Moneda mantenimiento,
        DateTime? fechaUltimaAlquiler,
        List<Accesorio> accesorios
    ) : base(id)
    {
        Modelo = modelo;
        Vin = vin;
        LocalidadId = localidadId;
        Precio = precio;
        Mantenimiento = mantenimiento;
        FechaUltimaAlquiler = fechaUltimaAlquiler;
        Accesorios = accesorios;
    }
}
