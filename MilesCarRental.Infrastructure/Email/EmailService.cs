using MilesCarRental.Application.Abstractions.Email;

namespace MilesCarRental.Infrastructure.Email;

internal sealed class EmailService : IEmailService
{
    public Task SendAsync(Domain.Users.Email recipent, string subject, string body)
    {
        return Task.CompletedTask;
    }
}
