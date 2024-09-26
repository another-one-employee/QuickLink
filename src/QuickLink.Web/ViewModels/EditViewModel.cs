using Microsoft.AspNetCore.Mvc;

namespace QuickLink.Web.ViewModels
{
    public class EditViewModel : CreateViewModel
    {
        [BindProperty]
        public string? ShortURL { get; set; }
    }
}
