using MilesCarRental.Domain.Abstractions;
using MilesCarRental.Domain.Localidades;

namespace MilesCarRental.Domain.Vehiculos;

public sealed class DisponibilidadVehiculo : Entity
{
    public Guid VehiculoId { get; private set; }
    public Guid LocalidadRecogidaId { get; private set; }
    public Guid LocalidadDevolucionId { get; private set; }
    public DateTime FechaInicio { get; private set; }
    public DateTime FechaFin { get; private set; }
    public bool Disponible { get; private set; }


    private DisponibilidadVehiculo() { }

    public DisponibilidadVehiculo(
        Guid id,
        Vehiculo vehiculo,
        Localidad localidadRecogida,
        Localidad localidadDevolucion,
        DateTime fechaInicio,
        DateTime fechaFin,
        bool disponible
    ) : base(id)
    {
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
        Disponible = disponible;
        VehiculoId = vehiculo.Id;
        LocalidadRecogidaId = localidadRecogida.Id;
        LocalidadDevolucionId = localidadDevolucion.Id;
    }

    public bool EstaDisponibleEn(DateTime fecha) =>
        Disponible && fecha >= FechaInicio && fecha <= FechaFin;
}

