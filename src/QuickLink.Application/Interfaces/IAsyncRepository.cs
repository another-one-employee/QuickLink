using System.Linq.Expressions;

namespace QuickLink.Application.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity : class
    {
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

        Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken);
    }
}
