using GFM.Fundation.App.Enuns;
using GFM.Fundation.Batch.Application.Commands.User.Create;
using GFM.Fundation.SimpleMediator.Interface;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace GFM.Fundation.Batch.Application.Commands.User;

[Command(Name = "User", Description = "UserBatchCommand comando")]
public class UserBatchCommand : ICommand
{
    private readonly ILogger<UserBatchCommand> _logger;
    private readonly IMediator _mediator;

    public UserBatchCommand(ILogger<UserBatchCommand> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public void OnExecute()
    {
        ExecuteAsync().GetAwaiter().GetResult();
    }

    private async Task ExecuteAsync()
    {
        try
        {
            _logger.LogInformation($"***************************************************************");
            _logger.LogInformation($"UserBatchCommand > ExecuteAsync > {DateTime.Now}");
            await _mediator.Send(new CreateUserCommand("Teste nome", "Teste Sobre nome", EGender.Male));
            _logger.LogInformation($"***************************************************************");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao executar UserBatchCommand");
            Console.WriteLine($"Erro: {ex.Message}");
            _logger.LogInformation($"Erro: {ex.Message}");
        }
    }
}

