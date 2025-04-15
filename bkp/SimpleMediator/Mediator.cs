using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var handler = _serviceProvider.GetRequiredService(handlerType);

        var behaviors = _serviceProvider.GetServices(typeof(IPipelineBehavior<,>).MakeGenericType(request.GetType(), typeof(TResponse)))
            .Cast<dynamic>().Reverse().ToList();

        RequestHandlerDelegate<TResponse> handlerDelegate = () => ((dynamic)handler).Handle((dynamic)request, cancellationToken);

        foreach (var behavior in behaviors)
        {
            var next = handlerDelegate;
            handlerDelegate = () => behavior.Handle((dynamic)request, cancellationToken, next);
        }

        return await handlerDelegate();
    }

    public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
        where TNotification : INotification
    {
        var handlers = _serviceProvider.GetServices<INotificationHandler<TNotification>>();
        var tasks = handlers.Select(h => h.Handle(notification, cancellationToken));
        await Task.WhenAll(tasks);
    }
}