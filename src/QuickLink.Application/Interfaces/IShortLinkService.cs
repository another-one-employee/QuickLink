using QuickLink.Application.Entities;

namespace QuickLink.Application.Interfaces
{
    public interface IShortLinkService
    {
        Task CreateAsync(string longUrl, CancellationToken cancellationToken);

        Task<ShortLink> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<IList<ShortLink>> GetAllAsync(CancellationToken cancellationToken);

        Task UpdateAsync(ShortLink entity, CancellationToken cancellationToken);

        Task DeleteAsync(int id, CancellationToken cancellationToken);

        Task IncrementClickCountAsync(int id, CancellationToken cancellationToken);
    }
}