using GFM.Fundation.App.Response;
using GFM.Fundation.Batch.Domain.User;
using GFM.Fundation.SimpleMediator.Interface;
using Microsoft.Extensions.Logging;

namespace GFM.Fundation.Batch.Application.Commands.User.Create;

public class CreateUserCommandHandler :
    IRequestHandler<CreateUserCommand, ApiResult<CreateUserResponse>>,
    IErrorHandler<CreateUserCommand>
{
    private readonly ILogger<CreateUserCommandHandler> _logger;
    private readonly IMediator _mediator;

    public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger,
                                    IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<ApiResult<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"***************************************************************");
        _logger.LogInformation($"CreateUserCommandHandler > {DateTime.Now}");
        var entity = new UserEntity(request.firstName, request.lastName, request.gender);


        // Executa eventos
        foreach (var domainEvent in entity.DomainEvents)
            await _mediator.Publish(domainEvent);
        entity.ClearDomainEvents();

        _logger.LogInformation($"***************************************************************");
        return ApiResult<CreateUserResponse>.CreateSuccess(
            new CreateUserResponse(entity.Id),
            "Cadastrado com sucesso!"
        );
    }

    public Task OnErrorAsync(CreateUserCommand request, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"***************************************************************");
        _logger.LogError(exception, "Erro ao processar CreateUserCommand. Dados recebidos: {@Request}", request);
        _logger.LogInformation($"***************************************************************");
        return Task.CompletedTask;
    }
}
