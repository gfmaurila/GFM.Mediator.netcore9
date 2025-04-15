using GFM.Fundation.SimpleMediator.Interface;

namespace GFM.Fundation.Batch.Application.Commands.User.Create;

public class CreateUserCommandValidator : IValidator<CreateUserCommand>
{
    public Task ValidateAsync(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.firstName))
            throw new Exception("O nome do usuario é obrigatório.");

        return Task.CompletedTask;
    }
}
