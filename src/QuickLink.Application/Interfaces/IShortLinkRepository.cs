using QuickLink.Application.Models;

namespace QuickLink.Application.Interfaces
{
    public interface IShortLinkRepository
    {
        Task CreateAsync(ShortLink shortLink, CancellationToken cancellationToken);

        Task<ShortLink> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<IList<ShortLink>> GetAllAsync(CancellationToken cancellationToken);

        Task UpdateAsync(ShortLink shortLink, CancellationToken cancellationToken);

        Task DeleteAsync(ShortLink shortLink, CancellationToken cancellationToken);
    }
}
