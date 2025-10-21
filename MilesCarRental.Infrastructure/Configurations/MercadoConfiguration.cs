using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilesCarRental.Domain.Mercados;

namespace MilesCarRental.Infrastructure.Configurations;

internal sealed class MercadoConfiguration : IEntityTypeConfiguration<Mercado>
{
    public void Configure(EntityTypeBuilder<Mercado> builder)
    {
        builder.ToTable("mercados");
        builder.HasKey(mercado => mercado.Id);

        builder.Property(mercado => mercado.Nombre)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(mercado => mercado.Descripcion)
            .HasMaxLength(500);
    }
}