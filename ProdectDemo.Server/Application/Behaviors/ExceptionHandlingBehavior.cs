using EntityFramework.Exceptions.Common;
using ErrorOr;
using MediatR;
using ProductDemo.Server.Domain.Errors.Common;

namespace ProductDemo.Server.Application.Behaviors;

public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{


    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        try
        {
            return await next();
        }
        catch (ReferenceConstraintException)
        {

            return (dynamic)CommonDomainErrors.ConflictWithReferenceConstraints;
        }
    }
}