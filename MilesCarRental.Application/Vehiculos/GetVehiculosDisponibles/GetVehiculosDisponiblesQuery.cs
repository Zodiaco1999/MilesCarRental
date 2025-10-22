using MilesCarRental.Application.Abstractions.Messaging;

namespace MilesCarRental.Application.Vehiculos.GetVehiculosDisponibles;

public record GetVehiculosDisponiblesQuery(
    Guid LocalidadRecogidaId,
    Guid? LocalidadDevolucionId,
    Guid? LocalidadClienteId,
    DateOnly? FechaInicio,
    DateOnly? FechaFin
) : IQuery<IReadOnlyList<VehiculoDisponibleResponse>>;
