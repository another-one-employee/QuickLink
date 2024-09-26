namespace QuickLink.Application.Models
{
    public class ShortLink
    {
        public virtual int Id { get; set; }

        public virtual string LongURL { get; set; } = default!;

        public virtual string ShortURL { get; set; } = default!;

        public virtual DateTime CreatedAt { get; set; }

        public virtual int ClickCount { get; set; }
    }
}
