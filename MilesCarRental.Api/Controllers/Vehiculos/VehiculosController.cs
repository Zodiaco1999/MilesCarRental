using MediatR;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Api.Controllers.Vehiculos;
using MilesCarRental.Application.Vehiculos.CreateVehiculo;
using MilesCarRental.Application.Vehiculos.GetVehiculosDisponibles;
using MilesCarRental.Domain.Shared;
using MilesCarRental.Domain.Vehiculos;


namespace CleanArquitecture.Api.Controllers.Vehiculos;

[Route("api/[controller]")]
[ApiController]
public class VehiculosController : ControllerBase
{
    private readonly ISender _sender;

    public VehiculosController(ISender sender) => _sender = sender;

    [HttpPost]
    public async Task<IActionResult> CreateVehiculo(CreateVehiculoRequest request, CancellationToken cancellationToken)
    {
        var vehiculo = new CreateVehiculoCommand(
            new Modelo(request.Modelo),
            new Vin(request.Vin),
            request.LocalidadId,
            new Moneda(request.PrecioMonto, TipoMoneda.FromCodigo(request.PrecioTipoMoneda)),
            new Moneda(request.MantenimientoMonto, TipoMoneda.FromCodigo(request.MantenimientoTipoMoneda)),
            request.Accesorios
        );

        var result = await _sender.Send(vehiculo, cancellationToken);

        return Ok(result.Value);
    }

    [HttpGet("disponibles")]
    public async Task<IActionResult> GetVehiculosDisponiblesPorLocalidad([FromQuery] GetVehiculosDisponiblesRequest request, CancellationToken cancellationToken)
    {
        var query = new GetVehiculosDisponiblesQuery(
            request.LocalidadRecogidaId,
            request.LocalidadDevolucionId,
            request.LocalidadClienteId,
            request.FechaInicio,
            request.FechaFin
        );
        var result = await _sender.Send(query, cancellationToken);
        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }
}
