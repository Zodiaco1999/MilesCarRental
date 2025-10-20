using MilesCarRental.Application.Abstractions.Messaging;

namespace MilesCarRental.Application.Vehiculos.SearchVehiculos;

public record SearchVehiculosQuery(
    DateOnly FechaInicio,
    DateOnly FechaFin
) : IQuery<IReadOnlyList<VehiculoResponse>>;