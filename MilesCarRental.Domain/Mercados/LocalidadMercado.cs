using MilesCarRental.Domain.Abstractions;
using MilesCarRental.Domain.Localidades;

namespace MilesCarRental.Domain.Mercados;

public sealed class LocalidadMercado : Entity
{
    public Guid LocalidadId { get; private set; }
    public Guid MercadoId { get; private set; }

    private LocalidadMercado() { }

    public LocalidadMercado(Guid id, Localidad localidad, Mercado mercado) : base(id)
    {
        LocalidadId = localidad.Id;
        MercadoId = mercado.Id;
    }
}