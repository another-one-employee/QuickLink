using Microsoft.AspNetCore.Mvc;
using QuickLink.Application.Interfaces;

namespace QuickLink.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShortLinkService _shortLinkService;

        public HomeController(IShortLinkService shortLinkService)
        {
            _shortLinkService = shortLinkService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await _shortLinkService.GetAllAsync(cancellationToken));
        }
    }
}
