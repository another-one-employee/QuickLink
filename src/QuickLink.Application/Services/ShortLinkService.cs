using AutoMapper;
using QuickLink.Application.Entities;
using QuickLink.Application.Exceptions;
using QuickLink.Application.Interfaces;
using System.Text;

namespace QuickLink.Application.Services
{
    public class ShortLinkService(IAsyncRepository<Models.ShortLink> repository, IMapper mapper) : IShortLinkService
    {
        private readonly IAsyncRepository<Models.ShortLink> _repository = repository;
        private readonly IMapper _mapper = mapper;

        private static readonly char[] _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        private static readonly int _length = 6;
        private static readonly Random _random = new();
        private static readonly string _schema = "https://q.link/";

        public async Task CreateAsync(string longUrl, CancellationToken cancellationToken)
        {
            bool isUrl = Uri.IsWellFormedUriString(longUrl, UriKind.Absolute);

            if (isUrl)
            {
                var shortUrl = _schema + GenerateShortLinkSegment();
                var entity = new ShortLink(longUrl, shortUrl);

                var model = _mapper.Map<Models.ShortLink>(entity);
                await _repository.InsertAsync(model, cancellationToken);
            }
            else
            {
                throw new InvalidUrlException($"{longUrl} is not correct URL");
            }
        }

        public async Task<ShortLink> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var model = await _repository.FindAsync(s => s.Id == id, cancellationToken);
            return _mapper.Map<ShortLink>(model);
        }

        public async Task<IList<ShortLink>> GetAllAsync(CancellationToken cancellationToken)
        {
            var models = await _repository.FindAllAsync(cancellationToken);
            return _mapper.Map<IList<ShortLink>>(models);
        }

        public async Task UpdateAsync(ShortLink entity, CancellationToken cancellationToken)
        {
            bool isUrl = Uri.IsWellFormedUriString(entity.LongUrl, UriKind.Absolute);

            if (isUrl)
            {
                var model = _mapper.Map<Models.ShortLink>(entity);
                await _repository.UpdateAsync(model, cancellationToken);
            }
            else
            {
                throw new InvalidUrlException($"{entity.LongUrl} is not correct URL");
            }
        }
        public async Task IncrementClickCountAsync(Guid id, CancellationToken cancellationToken)
        {
            var model = await _repository.FindAsync(s => s.Id == id, cancellationToken);
            model.ClickCount++;
            await _repository.UpdateAsync(model, cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var model = await _repository.FindAsync(s => s.Id == id, cancellationToken);
            await _repository.DeleteAsync(model, cancellationToken);
        }

        private static string GenerateShortLinkSegment()
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
