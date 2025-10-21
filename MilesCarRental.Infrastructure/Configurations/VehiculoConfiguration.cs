using MilesCarRental.Domain.Localidades;
using MilesCarRental.Domain.Shared;
using MilesCarRental.Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilesCarRental.Infrastructure.Configurations;

internal sealed class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
{
    public void Configure(EntityTypeBuilder<Vehiculo> builder)
    {
        builder.ToTable("vehiculos");

        builder.HasKey(v => v.Id);

        builder.Property(vehiculo => vehiculo.Modelo)
         .HasMaxLength(200)
         .HasConversion(modelo => modelo!.Value, value => new Modelo(value));

        builder.Property(vehiculo => vehiculo.Vin)
         .HasMaxLength(500)
         .HasConversion(vin => vin!.Value, value => new Vin(value));

        builder.Property(v => v.LocalidadId)
            .HasColumnName("localidad_id")
            .IsRequired();

        builder.OwnsOne(v => v.Precio, precioBuilder =>
        {
            precioBuilder.Property(m => m.Monto)
                .HasColumnName("precio_monto")
                .IsRequired();

            precioBuilder.Property(m => m.TipoMoneda)
                .HasColumnName("precio_tipo_moneda")
                .HasConversion(
                    tipo => tipo.Codigo,
                    codigo => TipoMoneda.FromCodigo(codigo!)
                )
                .IsRequired();
        });

        builder.OwnsOne(v => v.Mantenimiento, mantenimientoBuilder =>
        {
            mantenimientoBuilder.Property(m => m.Monto)
                .HasColumnName("mantenimiento_monto")
                .IsRequired();

            mantenimientoBuilder.Property(m => m.TipoMoneda)
                .HasColumnName("mantenimiento_tipo_moneda")
                .HasConversion(
                    tipo => tipo.Codigo,
                    codigo => TipoMoneda.FromCodigo(codigo!)
                )
                .IsRequired();
        });

        builder.Property(v => v.FechaUltimaAlquiler)
            .HasColumnName("fecha_ultima_alquiler");

        builder.HasOne<Localidad>()
            .WithMany()
            .HasForeignKey(v => v.LocalidadId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}