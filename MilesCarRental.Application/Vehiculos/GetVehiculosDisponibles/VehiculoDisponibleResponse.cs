namespace MilesCarRental.Application.Vehiculos.GetVehiculosDisponibles;

public sealed record VehiculoDisponibleResponse(
    Guid VehiculoId,
    string? Modelo,
    string? Vin,
    decimal PrecioMonto,
    string? PrecioTipoMoneda,
    decimal MantenimientoMonto,
    string? MantenimientoTipoMoneda,
    string? LocalidadRecogida,
    string? LocalidadDevolucion,
    string? Mercado,
    DateTime? FechaInicio,
    DateTime? FechaFin,
    bool Disponible
);