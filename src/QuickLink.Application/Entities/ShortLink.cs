namespace QuickLink.Application.Entities
{
    public class ShortLink(string longUrl, string shortUrl, DateTime? createdAt = null, int clickCount = 0, int id = 0)
    {
        public int Id { get; private set; } = id;

        public string LongUrl { get; private set; } = longUrl;

        public string ShortUrl { get; private set; } = shortUrl;

        public DateTime CreatedAt { get; private set; } = createdAt ?? DateTime.Now;

        public int ClickCount { get; private set; } = clickCount;
    }
}
