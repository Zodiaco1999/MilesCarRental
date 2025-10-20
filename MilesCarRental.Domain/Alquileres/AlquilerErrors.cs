using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Alquileres;

public static class AlquilerErrors
{
    public static readonly Error NotFound = new Error(
        "Alquiler.NotFound",
        "El alquiler no fue encontrado."
    );

    public static readonly Error Overlap = new Error(
        "Alquiler.Overlap",
        "El alquiler esta siendo tomado por dos o mas clientes al mismo tiempo en la misma fecha"
    );

    public static readonly Error NotReserved = new Error(
        "Alquiler.NotReserved",
        "El alquiler no está reservado."
    );

    public static readonly Error NotConfirmed = new Error(
        "Alquiler.NotConfirmed",
        "El alquiler no está confirmado."
    );

    public static readonly Error AlreadyStarted = new Error(
        "Alquiler.AlreadyStarted",
        "El alquiler ya ha comenzado."
    );
}
