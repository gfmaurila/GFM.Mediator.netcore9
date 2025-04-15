using GFM.Fundation.SimpleMediator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFM.Fundation.SimpleMediator.Behaviors;

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
