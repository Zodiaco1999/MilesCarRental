using MilesCarRental.Application.Abstractions.Messaging;

namespace MilesCarRental.Application.Alquileres.ReservarAlquiler;

public record ReservarAlquilerCommand(
    Guid VehiculoId,
    Guid UserId,
    DateOnly FechaInicio,
    DateOnly FechaFin
) : ICommand<Guid>;
