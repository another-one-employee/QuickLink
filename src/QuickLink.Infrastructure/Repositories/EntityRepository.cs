using Microsoft.EntityFrameworkCore;
using QuickLink.Application.Interfaces;
using System.Linq.Expressions;

namespace QuickLink.Infrastructure.Repositories
{
    public class EntityRepository<TEntity>(DbContext dbContext) : IAsyncRepository<TEntity>
       where TEntity : class
    {
        protected DbContext Context { get; } = dbContext;

        protected DbSet<TEntity> Set => Context.Set<TEntity>();

        public async Task InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await Set.AddAsync(entity, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Set.Remove(entity);
            await Context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await Set.AsNoTracking().FirstAsync(predicate, cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken)
        {
            return await Set.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
