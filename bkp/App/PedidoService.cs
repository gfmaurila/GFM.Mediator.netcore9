using System;
using System.Threading.Tasks;

public class PedidoService
{
    private readonly IMediator _mediator;

    public PedidoService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task CriarPedido()
    {
        var result = await _mediator.Send(new CreateOrderCommand { ProductName = "Notebook" });
        Console.WriteLine(result);
    }
}