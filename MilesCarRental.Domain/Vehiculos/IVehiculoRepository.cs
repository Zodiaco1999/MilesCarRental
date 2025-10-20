using MilesCarRental.Domain.Alquileres;

namespace MilesCarRental.Domain.Vehiculos;

public interface IVehiculoRepository
{
    Task<Vehiculo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Vehiculo vehiculo);
}
