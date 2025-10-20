using MilesCarRental.Domain.Abstractions;

namespace MilesCarRental.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
