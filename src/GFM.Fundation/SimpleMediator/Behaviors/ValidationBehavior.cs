using GFM.Fundation.SimpleMediator.Interface;

namespace GFM.Fundation.SimpleMediator.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        if (!_validators.Any())
        {
            throw new InvalidOperationException($"Nenhum validador registrado para {typeof(TRequest).Name}");
        }

        foreach (var validator in _validators)
        {
            await validator.ValidateAsync(request, cancellationToken);
        }

        return await next();
    }
}

