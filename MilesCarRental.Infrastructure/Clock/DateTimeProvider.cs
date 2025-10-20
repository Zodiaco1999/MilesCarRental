using MilesCarRental.Application.Abstractions.Clock;

namespace MilesCarRental.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public new DateTime CurrentTime => DateTime.UtcNow;

}
