using MilesCarRental.Application.Abstractions.Messaging;

namespace MilesCarRental.Application.Alquileres.GetAlquiler;

public sealed record GetAlquilerQuery(Guid AlquilerId) : IQuery<AlquilerResponse>;