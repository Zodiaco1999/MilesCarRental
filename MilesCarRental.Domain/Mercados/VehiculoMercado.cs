using MilesCarRental.Domain.Abstractions;
using MilesCarRental.Domain.Vehiculos;

namespace MilesCarRental.Domain.Mercados;

public sealed class VehiculoMercado : Entity
{
    public Guid VehiculoId { get; private set; }
    public Guid MercadoId { get; private set; }

    private VehiculoMercado() { }

    public VehiculoMercado(Guid id, Vehiculo vehiculo, Mercado mercado) : base(id)
    {
        VehiculoId = vehiculo.Id;
        MercadoId = mercado.Id;
    }
}
