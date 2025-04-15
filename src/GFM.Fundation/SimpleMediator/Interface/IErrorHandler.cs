namespace GFM.Fundation.SimpleMediator.Interface;

public interface IErrorHandler<TRequest>
{
    Task OnErrorAsync(TRequest request, Exception exception, CancellationToken cancellationToken);
}
