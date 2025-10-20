using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Application.Vehiculos.CreateVehiculo;

internal sealed class CreateVehiculoCommandHandler : ICommandHandler<CreateVehiculoCommand, Guid>
{
    private readonly IVehiculoRepository _vehiculoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehiculoCommandHandler(IVehiculoRepository vehiculoRepository, IUnitOfWork unitOfWork)
    {
        _vehiculoRepository = vehiculoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateVehiculoCommand request, CancellationToken cancellationToken)
    {
        var vehiculo = new Vehiculo(
            Guid.NewGuid(),
            request.Modelo!,
            request.Direccion!,
            request.Vin!,
            request.Precio,
            request.Mantenimiento,
            DateTime.UtcNow,
            request.Accesorios);

        _vehiculoRepository.Add(vehiculo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success(vehiculo.Id);
    }
}
