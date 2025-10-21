using MilesCarRental.Domain.Vehiculos;

namespace CleanArquitecture.Api.Controllers.Vehiculos;

public record CreateVehiculoRequest(
    string Modelo,
    string Vin,
    Guid LocalidadId,
    decimal PrecioMonto,
    string PrecioTipoMoneda,
    decimal MantenimientoMonto,
    string MantenimientoTipoMoneda,
    List<Accesorio> Accesorios
);
