using GFM.Fundation.App.Enuns;
using GFM.Fundation.App.Response;
using GFM.Fundation.SimpleMediator.Interface;

namespace GFM.Fundation.Batch.Application.Commands.User.Create;

public record CreateUserCommand(string firstName, string lastName, EGender gender) : IRequest<ApiResult<CreateUserResponse>>;
