using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var services = new ServiceCollection();
        services.AddScoped<IMediator, Mediator>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<IValidator<CreateOrderCommand>, CreateOrderValidator>();
        services.AddScoped<IRequestHandler<CreateOrderCommand, string>, CreateOrderHandler>();
        services.AddScoped<INotificationHandler<OrderCreatedNotification>, SendEmailOnOrderCreated>();
        services.AddScoped<INotificationHandler<OrderCreatedNotification>, SaveLogOnOrderCreated>();
        services.AddScoped<PedidoService>();

        var provider = services.BuildServiceProvider();
        var service = provider.GetRequiredService<PedidoService>();

        await service.CriarPedido();
    }
}