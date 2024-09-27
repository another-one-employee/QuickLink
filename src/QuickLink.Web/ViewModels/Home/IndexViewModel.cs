using QuickLink.Application.Entities;
using System.ComponentModel.DataAnnotations;

namespace QuickLink.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public IList<ShortLink>? ShortLinks { get; set; }

        [Url]
        public string? NewLongUrl { get; set; } = default!;
    }
}
