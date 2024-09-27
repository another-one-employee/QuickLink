using NHibernate;
using QuickLink.Application.Models;
using QuickLink.Application.Interfaces;

namespace QuickLink.Infrastructure.Repositories
{
    public class ShortLinkRepository(ISessionFactory sessionFactory) : IShortLinkRepository
    {
        private readonly ISessionFactory _sessionFactory = sessionFactory;

        public async Task CreateAsync(ShortLink shortLink, CancellationToken cancellationToken)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            await session.SaveAsync(shortLink, cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }

        public async Task<ShortLink> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            using var session = _sessionFactory.OpenSession();
            return await session.GetAsync<ShortLink>(id, cancellationToken);
        }

        public async Task<IList<ShortLink>> GetAllAsync(CancellationToken cancellationToken)
        {
            using var session = _sessionFactory.OpenSession();
            return await session
                .CreateCriteria<ShortLink>()
                .ListAsync<ShortLink>(cancellationToken);
        }

        public async Task UpdateAsync(ShortLink shortLink, CancellationToken cancellationToken)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            await session.UpdateAsync(shortLink, cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }

        public async Task DeleteAsync(ShortLink shortLink, CancellationToken cancellationToken)
        {
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            await session.DeleteAsync(shortLink, cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
    }
}
