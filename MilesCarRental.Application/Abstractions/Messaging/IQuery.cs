using MilesCarRental.Domain.Abstractions;
using MediatR;

namespace MilesCarRental.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}
