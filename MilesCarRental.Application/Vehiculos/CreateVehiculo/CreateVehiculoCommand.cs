using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Domain.Vehiculos;
using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.Vehiculos.CreateVehiculo;

public record CreateVehiculoCommand(
    Modelo? Modelo,
    Vin? Vin,
    Direccion? Direccion,
    Moneda Precio,
    Moneda Mantenimiento,
    DateTime? FechaUltimaAlquiler,
    List<Accesorio> Accesorios
    ) : ICommand<Guid>;
