using MilesCarRental.Domain.Abstractions;

namespace MilesCarRental.Domain.Reviews.Events;

public sealed record ReviewCreadoDomainEvent(Guid AlquilerId) : IDomainEvent;