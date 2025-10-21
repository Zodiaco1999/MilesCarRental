using MilesCarRental.Domain.Abstractions;

namespace MilesCarRental.Domain.Vehiculos;

public static class VehiculoErrors
{
    public static Error NotFound = new("Vehiculo.NotFound", "No existe el vehiculo buscado por este id");
    public static Error LocalidadRecogida = new("Vehiculo.LocalidadRecogida", "La LocalidadRecogidaId es obligatoria");
}
