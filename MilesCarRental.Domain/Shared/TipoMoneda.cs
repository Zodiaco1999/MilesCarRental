namespace CleanArchitecture.Domain.Shared;

public record TipoMoneda
{
    public static readonly TipoMoneda None = new TipoMoneda("");
    public static readonly TipoMoneda Usd = new TipoMoneda("USD");
    public static readonly TipoMoneda Eur = new TipoMoneda("EUR");
    private TipoMoneda(string codigo) => Codigo = codigo;
    public string? Codigo { get; init; }
    public static readonly IReadOnlyCollection<TipoMoneda> All = [
        Usd,
        Eur
    ];

    public static TipoMoneda FromCodigo(string codigo)
    {
        return All.FirstOrDefault(c => c.Codigo == codigo) ??
            throw new ApplicationException("Tipo de moneda es invalido");
    }
}
