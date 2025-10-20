using MilesCarRental.Domain.Abstractions;

namespace MilesCarRental.Domain.Alquileres.Events;

public sealed record AlquilerReservadoDomainEvent(Guid AlquilerId) : IDomainEvent;