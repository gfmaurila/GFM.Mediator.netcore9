using System;
using System.Threading;
using System.Threading.Tasks;

public class CreateOrderValidator : IValidator<CreateOrderCommand>
{
    public Task ValidateAsync(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.ProductName))
            throw new Exception("O nome do produto é obrigatório.");

        return Task.CompletedTask;
    }
}