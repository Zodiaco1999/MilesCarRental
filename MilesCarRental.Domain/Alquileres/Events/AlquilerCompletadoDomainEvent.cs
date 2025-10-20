using MilesCarRental.Domain.Abstractions;

namespace MilesCarRental.Domain.Alquileres.Events;

public sealed record AlquilerCompletadoDomainEvent(Guid AlquilerId) : IDomainEvent;
