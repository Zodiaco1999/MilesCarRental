using MilesCarRental.Domain.Abstractions;
using MediatR;

namespace MilesCarRental.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{

}