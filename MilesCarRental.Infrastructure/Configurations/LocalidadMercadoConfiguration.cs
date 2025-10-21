using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilesCarRental.Domain.Localidades;
using MilesCarRental.Domain.Mercados;

namespace MilesCarRental.Infrastructure.Configurations;

internal sealed class LocalidadMercadoConfiguration : IEntityTypeConfiguration<LocalidadMercado>
{
    public void Configure(EntityTypeBuilder<LocalidadMercado> builder)
    {
        builder.ToTable("localidad_mercado");
        builder.HasKey(lm => lm.Id);

        builder.HasOne<Localidad>()
            .WithMany()
            .HasForeignKey(lm => lm.LocalidadId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Mercado>()
            .WithMany()
            .HasForeignKey(lm => lm.MercadoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}