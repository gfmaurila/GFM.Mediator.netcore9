public class CreateOrderCommand : IRequest<string>
{
    public string ProductName { get; set; }
}