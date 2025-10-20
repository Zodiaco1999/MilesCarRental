using FluentValidation;

namespace CleanArchitecture.Application.Vehiculos.CreateVehiculo;

public class CreateVehiculoCommandValidator : AbstractValidator<CreateVehiculoCommand>
{
    public CreateVehiculoCommandValidator()
    {
        RuleFor(x => x.Modelo)
            .NotEmpty()
            .WithMessage("El modelo es obligatorio.");
    }
}
