using MilesCarRental.Domain.Vehiculos;

namespace MilesCarRental.Infrastructure.Repositories;

internal sealed class VehiculoRepository : Repository<Vehiculo>, IVehiculoRepository
{
    public VehiculoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
