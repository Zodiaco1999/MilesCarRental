using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Reviews.Events;

public sealed record ReviewCreadoDomainEvent(Guid AlquilerId) : IDomainEvent;