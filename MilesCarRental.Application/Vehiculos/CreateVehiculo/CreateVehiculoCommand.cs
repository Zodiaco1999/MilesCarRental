using MilesCarRental.Application.Abstractions.Messaging;
using MilesCarRental.Domain.Shared;
using MilesCarRental.Domain.Vehiculos;

namespace MilesCarRental.Application.Vehiculos.CreateVehiculo;

public record CreateVehiculoCommand(
    Modelo? Modelo,
    Vin? Vin,
    Guid LocalidadId,
    Moneda Precio,
    Moneda Mantenimiento,
    List<Accesorio> Accesorios
    ) : ICommand<Guid>;
