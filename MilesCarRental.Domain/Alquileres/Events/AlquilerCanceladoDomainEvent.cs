using MilesCarRental.Domain.Abstractions;

namespace MilesCarRental.Domain.Alquileres.Events;

public sealed record AlquilerCanceladoDomainEvent(Guid AlquilerId) : IDomainEvent;