using System.Threading;
using System.Threading.Tasks;

public interface IValidator<TRequest>
{
    Task ValidateAsync(TRequest request, CancellationToken cancellationToken);
}