using CleanArchitecture.Application.Vehiculos.CreateVehiculo;
using CleanArchitecture.Application.Vehiculos.SearchVehiculos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Domain.Vehiculos;
using CleanArchitecture.Domain.Shared;


namespace CleanArquitecture.Api.Controllers.Vehiculos;

[Route("api/[controller]")]
[ApiController]
public class VehiculosController : ControllerBase
{
    private readonly ISender _sender;

    public VehiculosController(ISender sender) => _sender = sender;

    [HttpGet]
    public async Task<IActionResult> SearchVehiculos(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken)
    {
        var query = new SearchVehiculosQuery(startDate, endDate);
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehiculo(CreateVehiculoRequest request, CancellationToken cancellationToken)
    {
        var vehiculo = new CreateVehiculoCommand(
            new Modelo(request.Modelo),
            new Vin(request.Vin),
            new Direccion(request.Pais, request.Departamento, request.Provincia, request.Ciudad, request.Calle),
            new Moneda(request.PrecioMonto, TipoMoneda.FromCodigo(request.PrecioTipoMoneda)),
            new Moneda(request.MantenimientoMonto, TipoMoneda.FromCodigo(request.MantenimientoTipoMoneda)),
            null,
            request.Accesorios
        );

        var result = await _sender.Send(vehiculo, cancellationToken);

        return Ok(result.Value);
    }



}
