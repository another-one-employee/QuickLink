using Microsoft.AspNetCore.Mvc;

namespace QuickLink.Web.ViewModels
{
    [IgnoreAntiforgeryToken]
    public class CreateViewModel
    {
        [BindProperty]
        public string? LongURL { get; set; }
    }
}
