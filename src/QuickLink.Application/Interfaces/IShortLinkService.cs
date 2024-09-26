using QuickLink.Application.Entities;

namespace QuickLink.Application.Interfaces
{
    public interface IShortLinkService
    {
        Task CreateAsync(string longUrl, CancellationToken cancellationToken);
        Task DeleteAsync(ShortLink shortLink, CancellationToken cancellationToken);
        Task<ShortLink> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IList<ShortLink>> GetAllAsync(CancellationToken cancellationToken);
        Task UpdateAsync(ShortLink shortLink, CancellationToken cancellationToken);
        Task IncrementClickCountAsync(ShortLink shortLink, CancellationToken cancellationToken);
    }
}