using MilesCarRental.Domain.Abstractions;

namespace MilesCarRental.Domain.Alquileres.Events;

public sealed record AlquilerConfirmadoDomainEvent(Guid AlquilerId) : IDomainEvent;