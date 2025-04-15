using System;
using System.Threading;
using System.Threading.Tasks;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, string>
{
    private readonly IMediator _mediator;

    public CreateOrderHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderId = Guid.NewGuid().ToString();
        await _mediator.Publish(new OrderCreatedNotification
        {
            OrderId = orderId,
            CreatedAt = DateTime.UtcNow
        });

        return $"Pedido {orderId} criado com sucesso!";
    }
}