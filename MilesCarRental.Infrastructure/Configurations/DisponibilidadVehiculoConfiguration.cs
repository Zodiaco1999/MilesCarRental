using MilesCarRental.Domain.Localidades;
using MilesCarRental.Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilesCarRental.Infrastructure.Configurations;

internal sealed class DisponibilidadVehiculoConfiguration : IEntityTypeConfiguration<DisponibilidadVehiculo>
{
    public void Configure(EntityTypeBuilder<DisponibilidadVehiculo> builder)
    {
        builder.ToTable("disponibilidad_vehiculo");
        builder.HasKey(dv => dv.Id);

        builder.Property(dv => dv.FechaInicio)
            .HasColumnName("fecha_inicio")
            .IsRequired();

        builder.Property(dv => dv.FechaFin)
            .HasColumnName("fecha_fin")
            .IsRequired();

        builder.Property(dv => dv.Disponible)
            .HasColumnName("disponible")
            .IsRequired();

        builder.Property(dv => dv.VehiculoId)
            .HasColumnName("vehiculo_id")
            .IsRequired();

        builder.Property(dv => dv.LocalidadRecogidaId)
            .HasColumnName("localidad_recogida_id")
            .IsRequired();

        builder.Property(dv => dv.LocalidadDevolucionId)
            .HasColumnName("localidad_devolucion_id")
            .IsRequired();

        builder.HasOne<Vehiculo>()
            .WithMany()
            .HasForeignKey(dv => dv.VehiculoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Localidad>()
            .WithMany()
            .HasForeignKey(dv => dv.LocalidadRecogidaId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_DisponibilidadVehiculo_LocalidadRecogida");

        builder.HasOne<Localidad>()
            .WithMany()
            .HasForeignKey(dv => dv.LocalidadDevolucionId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_DisponibilidadVehiculo_LocalidadDevolucion");
    }
}
