using System.ComponentModel.DataAnnotations;

namespace QuickLink.Web.ViewModels.Home
{
    public class EditViewModel
    {
        public Guid Id { get; set; }

        public string OldLongUrl { get; set; } = default!;

        [Url]
        [Required]
        public string NewLongUrl { get; set; } = default!;

        public string ShortUrl { get; set; } = default!;

        public DateTime CreatedAt { get; set; }

        public int ClickCount { get; set; }
    }
}
