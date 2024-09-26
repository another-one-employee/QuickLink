using Microsoft.AspNetCore.Mvc;
using QuickLink.Application.Interfaces;
using QuickLink.Web.ViewModels;

namespace QuickLink.Web.Controllers
{
    public class ShortLinkController : Controller
    {
        private readonly IShortLinkService _shortLinkService;

        public ShortLinkController(IShortLinkService shortLinkService)
        {
            _shortLinkService = shortLinkService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {

                await _shortLinkService.CreateAsync(model.LongURL, cancellationToken);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var shortLink = await _shortLinkService.GetByIdAsync(id, cancellationToken);
            return View();
        }
    }
}
