using GFM.Fundation.SimpleMediator.Interface;

namespace GFM.Fundation.SimpleMediator.Behaviors;

public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        try
        {
            return await next();
        }
        catch (ValidationException ex)
        {
            Console.WriteLine($"[VALIDAÇÃO] {ex.Message}");
            throw; 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERRO] {typeof(TRequest).Name}: {ex.Message}");
            throw new ApplicationException("Erro inesperado no processamento.", ex);
        }
    }
}