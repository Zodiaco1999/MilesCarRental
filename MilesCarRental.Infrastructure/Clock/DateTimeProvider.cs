using MilesCarRental.Application.Abstractions.Clock;

namespace MilesCarRental.Infrastructure.Clock;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public new DateTime CurrentTime => DateTime.UtcNow;

}
