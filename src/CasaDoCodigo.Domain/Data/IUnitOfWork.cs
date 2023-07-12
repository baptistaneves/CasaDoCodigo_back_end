namespace CasaDoCodigo.Domain.Data;

public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
}
