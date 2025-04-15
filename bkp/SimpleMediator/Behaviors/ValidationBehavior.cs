using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if (!_validators.Any())
            throw new InvalidOperationException($"Nenhum validador registrado para {typeof(TRequest).Name}");

        foreach (var validator in _validators)
        {
            await validator.ValidateAsync(request, cancellationToken);
        }

        return await next();
    }
}