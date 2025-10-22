using FluentValidation;

namespace MilesCarRental.Application.Vehiculos.GetVehiculosDisponibles;

public class GetVehiculosDisponiblesQueryValidator : AbstractValidator<GetVehiculosDisponiblesQuery>
{
    private const string MensajeFechas = "Si se proporciona una fecha, ambas (FechaInicio y FechaFin) deben estar presentes.";
    public GetVehiculosDisponiblesQueryValidator()
    {
        RuleFor(x => x.LocalidadRecogidaId)
            .NotEmpty();
        RuleFor(x => x).Custom((q, context) =>
        {
            var hasInicio = q.FechaInicio.HasValue;
            var hasFin = q.FechaFin.HasValue;

            // Una está presente y la otra no -> fallo
            if (hasInicio ^ hasFin)
            {
                if (!hasInicio)
                    context.AddFailure(nameof(q.FechaInicio), MensajeFechas);
                if (!hasFin)
                    context.AddFailure(nameof(q.FechaFin), MensajeFechas);

                return;
            }

            if (hasInicio && hasFin)
            {
                if (q.FechaInicio!.Value > q.FechaFin!.Value)
                    context.AddFailure(nameof(q.FechaInicio), "FechaInicio no puede ser posterior a FechaFin.");
            }
        });

    }
}

