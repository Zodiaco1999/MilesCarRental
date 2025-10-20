using MilesCarRental.Domain.Abstractions;

namespace MilesCarRental.Domain.Alquileres.Events;

public sealed record AlquilerRechazadoDomainEvent(Guid AlquilerId) : IDomainEvent;
