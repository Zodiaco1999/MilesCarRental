namespace MilesCarRental.Application.Abstractions.Clock;

public interface IDateTimeProvider
{
    public DateTime CurrentTime { get; }
}
