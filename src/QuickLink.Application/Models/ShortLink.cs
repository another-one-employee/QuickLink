namespace QuickLink.Application.Models
{
    public class ShortLink
    {
        public int Id { get; set; }

        public string LongUrl { get; set; } = default!;

        public string ShortUrl { get; set; } = default!;

        public DateTime CreatedAt { get; set; }

        public int ClickCount { get; set; }
    }
}
