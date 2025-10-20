using MilesCarRental.Domain.Alquileres;
using MilesCarRental.Domain.Reviews;
using MilesCarRental.Domain.Users;
using MilesCarRental.Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MilesCarRental.Infrastructure.Configurations;

internal sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("reviews");

        builder.HasKey(review => review.Id);

        builder.Property(review => review.Rating)
        .HasConversion(rating => rating.Value, value => Rating.Create(value).Value);

        builder.Property(review => review.Comentario)
        .HasMaxLength(200)
        .HasConversion(comentario => comentario.Value, value => new Comentario(value));

        builder.HasOne<Vehiculo>()
        .WithMany()
        .HasForeignKey(review => review.VehiculoId);

        builder.HasOne<Alquiler>()
        .WithMany()
        .HasForeignKey(review => review.AlquilerId);

        builder.HasOne<User>()
        .WithMany()
        .HasForeignKey(review => review.UserId);




    }
}