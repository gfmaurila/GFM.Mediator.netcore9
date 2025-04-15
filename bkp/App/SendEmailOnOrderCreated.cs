using System;
using System.Threading;
using System.Threading.Tasks;

public class SendEmailOnOrderCreated : INotificationHandler<OrderCreatedNotification>
{
    public Task Handle(OrderCreatedNotification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[Email] Enviando confirmação para pedido {notification.OrderId}");
        return Task.CompletedTask;
    }
}