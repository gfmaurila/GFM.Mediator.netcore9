using GFM.Fundation.App.Response;

namespace GFM.Fundation.Batch.Application.Commands.User.Create;

public class CreateUserResponse : BaseResponse
{
    public CreateUserResponse(Guid id) => Id = id;

    public Guid Id { get; }
}
