using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Domain.Vehiculos;

namespace CleanArquitecture.Api.Controllers.Vehiculos;

public record CreateVehiculoRequest(   
    string Modelo,
    string Vin,
    string Pais,
    string Departamento,
    string Provincia,
    string Ciudad,
    string Calle,
    decimal PrecioMonto,
    string PrecioTipoMoneda,
    decimal MantenimientoMonto,
    string MantenimientoTipoMoneda,
    List<Accesorio> Accesorios
);
