using CleanArchitecture.Infraestructure;
using CleanArquitecture.Api.Middleware;
using Microsoft.EntityFrameworkCore;

namespace CleanArquitecture.Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static async Task ApplyMigration(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var service = scope.ServiceProvider;
            var loggerFactory = service.GetRequiredService<ILoggerFactory>();

            try
            {
                var context = service.GetRequiredService<ApplicationDbContext>();
                if (!await context.Database.CanConnectAsync())
                {
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger("ApplyMigration");
                logger.LogError(ex, "An error occurred while applying migrations.");
                throw;
            }
        }
    }

    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
