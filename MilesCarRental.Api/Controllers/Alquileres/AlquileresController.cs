using CleanArchitecture.Application.Alquileres.GetAlquiler;
using CleanArchitecture.Application.Alquileres.ReservarAlquiler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArquitecture.Api.Controllers.Alquileres;

[Route("api/[controller]")]
[ApiController]
public class AlquileresController : ControllerBase
{
    private readonly ISender _sender;

    public AlquileresController(ISender sender) => _sender = sender;

    [HttpGet("{id}")]
    public async Task<IActionResult> ReservarAlquiler(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetAlquilerQuery(id);
        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> ReservarAlquiler(AlquilerReservaRequest alquilerRequest, CancellationToken cancellationToken)
    {
        var command = new ReservarAlquilerCommand(
            alquilerRequest.VehiculoId,
            alquilerRequest.UserId,
            alquilerRequest.StartDate,
            alquilerRequest.EndDate
        );
        var result = await _sender.Send(command, cancellationToken);
        return result.IsFailure ? BadRequest(result.Error) : CreatedAtAction(nameof(ReservarAlquiler), new { id = result.Value }, result.Value);
    }
}
