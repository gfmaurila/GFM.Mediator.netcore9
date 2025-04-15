using GFM.Fundation.Batch.Domain.User.Events;
using GFM.Fundation.SimpleMediator.Interface;
using Microsoft.Extensions.Logging;

namespace GFM.Fundation.Batch.Application.Commands.User.Create.Events;

public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
{
    private readonly ILogger<UserCreatedEventHandler> _logger;
    public UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"***************************************************************");
        _logger.LogInformation($"User > Domain > UserCreatedEvent > {DateTime.Now}");
        _logger.LogInformation($"***************************************************************");
    }
}
