namespace MilesCarRental.Api.Controllers.Vehiculos;

public sealed record GetVehiculosDisponiblesRequest(
    Guid LocalidadRecogidaId,
    Guid? LocalidadDevolucionId,
    Guid? LocalidadClienteId,
    DateOnly? FechaInicio,
    DateOnly? FechaFin
);
