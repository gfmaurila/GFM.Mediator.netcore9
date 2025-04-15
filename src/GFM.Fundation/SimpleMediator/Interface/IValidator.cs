namespace GFM.Fundation.SimpleMediator.Interface;

public interface IValidator<TRequest>
{
    Task ValidateAsync(TRequest request, CancellationToken cancellationToken);
}
