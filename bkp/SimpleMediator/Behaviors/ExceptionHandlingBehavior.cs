using System;
using System.Threading;
using System.Threading.Tasks;

public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] {typeof(TRequest).Name}: {ex.Message}");
            throw;
        }
    }
}