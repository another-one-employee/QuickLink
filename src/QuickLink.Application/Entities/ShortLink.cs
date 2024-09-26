namespace QuickLink.Application.Entities
{
    public class ShortLink(string longUrl, string shortUrl)
    {
        public int Id { get; private set; }

        public string LongURL { get; private set; } = longUrl;

        public string ShortURL { get; private set; } = shortUrl;

        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        public int ClickCount { get; private set; } = 0;

        public void IncrementClickCount()
        {
            ClickCount++;
        }
    }
}
