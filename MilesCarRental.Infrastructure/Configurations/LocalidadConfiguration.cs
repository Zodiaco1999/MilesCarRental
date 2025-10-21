using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MilesCarRental.Domain.Localidades;

namespace MilesCarRental.Infrastructure.Configurations;

internal sealed class LocalidadConfiguration : IEntityTypeConfiguration<Localidad>
{
    public void Configure(EntityTypeBuilder<Localidad> builder)
    {
        builder.ToTable("localidades");
        builder.HasKey(localidad => localidad.Id);

        builder.Property(localidad => localidad.Nombre)
            .HasMaxLength(100)
            .IsRequired();

        builder.OwnsOne(localidad => localidad.Direccion, direccionBuilder =>
        {
            direccionBuilder.Property(d => d.Pais).HasColumnName("pais").HasMaxLength(100);
            direccionBuilder.Property(d => d.Departamento).HasColumnName("departamento").HasMaxLength(100);
            direccionBuilder.Property(d => d.Provincia).HasColumnName("provincia").HasMaxLength(100);
            direccionBuilder.Property(d => d.Ciudad).HasColumnName("ciudad").HasMaxLength(100);
            direccionBuilder.Property(d => d.Calle).HasColumnName("calle").HasMaxLength(200);
        });
    }
}
