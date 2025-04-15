using GFM.Fundation.App.Response;
using GFM.Fundation.Batch.Application.Commands.User.Create;
using GFM.Fundation.Batch.Application.Commands.User.Create.Events;
using GFM.Fundation.Batch.Domain.User.Events;
using GFM.Fundation.SimpleMediator;
using GFM.Fundation.SimpleMediator.Behaviors;
using GFM.Fundation.SimpleMediator.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace GFM.Fundation.Batch.CrossCutting.InjecaoDependencia;

public static class MediatorServiceCollectionExtension
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator>();

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // User
        // Handlers
        services.AddScoped<IRequestHandler<CreateUserCommand, ApiResult<CreateUserResponse>>, CreateUserCommandHandler>();

        // Event Handlers (notificações)
        services.AddScoped<INotificationHandler<UserCreatedEvent>, UserCreatedEventHandler>();

        // Validators
        services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();

        return services;
    }
}
