using MilesCarRental.Domain.Abstractions;
using MediatR;

namespace MilesCarRental.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseRequest
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseRequest
{
}

public interface IBaseCommand
{}
