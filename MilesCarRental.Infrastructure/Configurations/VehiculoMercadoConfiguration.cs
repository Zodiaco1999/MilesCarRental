using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilesCarRental.Domain.Mercados;
using MilesCarRental.Domain.Vehiculos;

namespace MilesCarRental.Infrastructure.Configurations;

internal sealed class VehiculoMercadoConfiguration : IEntityTypeConfiguration<VehiculoMercado>
{
    public void Configure(EntityTypeBuilder<VehiculoMercado> builder)
    {
        builder.ToTable("vehiculo_mercado");
        builder.HasKey(vm => vm.Id);

        builder.HasOne<Vehiculo>()
            .WithMany()
            .HasForeignKey(vm => vm.VehiculoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Mercado>()
            .WithMany()
            .HasForeignKey(vm => vm.MercadoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}