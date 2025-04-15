using System;
using System.Threading;
using System.Threading.Tasks;

public class SaveLogOnOrderCreated : INotificationHandler<OrderCreatedNotification>
{
    public Task Handle(OrderCreatedNotification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[Log] Pedido {notification.OrderId} criado em {notification.CreatedAt}");
        return Task.CompletedTask;
    }
}