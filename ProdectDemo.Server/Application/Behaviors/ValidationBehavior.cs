using ErrorOr;
using FluentValidation;
using MediatR;

namespace ProductDemo.Server.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        if (_validator is null) return await next();

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid) return await next();



        List<Error> errors = new();

        foreach (var failure in validationResult.Errors)
        {
            if (failure.CustomState is null)        //if validation returns a built-in method            
            {
                errors.Add(Error.Validation(
                    code: failure.PropertyName,
                    description: failure.ErrorMessage
                ));
            }
            else       //if validation returns WithState--a DomainError            
            {
                errors.Add((Error)failure.CustomState);
            }
        }

        return (dynamic)errors;
    }
}

