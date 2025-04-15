using System;

public class OrderCreatedNotification : INotification
{
    public string OrderId { get; set; }
    public DateTime CreatedAt { get; set; }
}