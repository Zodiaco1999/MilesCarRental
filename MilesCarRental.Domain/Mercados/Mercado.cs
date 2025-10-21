using MilesCarRental.Domain.Abstractions;

namespace MilesCarRental.Domain.Mercados;

public sealed class Mercado : Entity
{
    public string Nombre { get; private set; }
    public string Descripcion { get; private set; }

    private Mercado() { }

    public Mercado(Guid id, string nombre, string codigo) : base(id)
    {
        Nombre = nombre;
        Descripcion = codigo;
    }
}
