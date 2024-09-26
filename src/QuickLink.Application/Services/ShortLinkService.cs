using AutoMapper;
using QuickLink.Application.Entities;
using QuickLink.Application.Exceptions;
using QuickLink.Application.Interfaces;
using System.Text;

namespace QuickLink.Application.Services
{
    public class ShortLinkService(IShortLinkRepository repository, IMapper mapper) : IShortLinkService
    {
        private readonly IShortLinkRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        private static readonly char[] _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        private static readonly int _length = 6;
        private static readonly Random _random = new();

        public async Task CreateAsync(string longUrl, CancellationToken cancellationToken)
        {
            bool isUrl = Uri.IsWellFormedUriString(longUrl, UriKind.Absolute);

            if (isUrl)
            {
                var shortUrl = GenerateShortLink();
                var shortLink = new ShortLink(longUrl, shortUrl);

                var model = _mapper.Map<Models.ShortLink>(shortLink);
                await _repository.CreateAsync(model, cancellationToken);
            }
            else
            {
                throw new InvalidUrlException($"{longUrl} is not correct URL");
            }
        }

        public async Task<ShortLink> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<ShortLink>(model);
        }

        public async Task<IList<ShortLink>> GetAllAsync(CancellationToken cancellationToken)
        {
            var models = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<IList<ShortLink>>(models);
        }

        public async Task UpdateAsync(ShortLink shortLink, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Models.ShortLink>(shortLink);

            model.CreatedAt = DateTime.UtcNow;
            model.ClickCount = 0;

            await _repository.UpdateAsync(model, cancellationToken);
        }
        public async Task IncrementClickCountAsync(ShortLink shortLink, CancellationToken cancellationToken)
        {
            shortLink.IncrementClickCount();
            var model = _mapper.Map<Models.ShortLink>(shortLink);
            await _repository.UpdateAsync(model, cancellationToken);
        }

        public async Task DeleteAsync(ShortLink shortLink, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Models.ShortLink>(shortLink);
            await _repository.DeleteAsync(model, cancellationToken);
        }

        private static string GenerateShortLink()
        {
            var shortUrl = new StringBuilder(_length);

            for (int i = 0; i < _length; i++)
            {
                shortUrl.Append(_chars[_random.Next(_chars.Length)]);
            }

            return shortUrl.ToString();
        }
    }
}
