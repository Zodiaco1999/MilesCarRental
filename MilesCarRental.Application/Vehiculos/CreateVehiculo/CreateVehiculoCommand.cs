using MilesCarRental.Domain.Shared;
using MilesCarRental.Domain.Vehiculos;
using MilesCarRental.Application.Abstractions.Messaging;

namespace MilesCarRental.Application.Vehiculos.CreateVehiculo;

public record CreateVehiculoCommand(
    Modelo? Modelo,
    Vin? Vin,
    Direccion? Direccion,
    Moneda Precio,
    Moneda Mantenimiento,
    DateTime? FechaUltimaAlquiler,
    List<Accesorio> Accesorios
    ) : ICommand<Guid>;
