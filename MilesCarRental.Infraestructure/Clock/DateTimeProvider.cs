using CleanArchitecture.Application.Abstractions.Clock;

namespace CleanArchitecture.Infraestructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public new DateTime CurrentTime => DateTime.UtcNow;

}
