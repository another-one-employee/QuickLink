using Microsoft.AspNetCore.Mvc;
using QuickLink.Application.Entities;
using QuickLink.Application.Interfaces;
using QuickLink.Web.ViewModels.Home;

namespace QuickLink.Web.Controllers
{
    public class HomeController(IShortLinkService shortLinkService) : Controller
    {
        private readonly IShortLinkService _shortLinkService = shortLinkService;

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var model = new IndexViewModel
            {
                ShortLinks = await _shortLinkService.GetAllAsync(cancellationToken)
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IndexViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid && model.NewLongUrl is not null)
            {
                await _shortLinkService.CreateAsync(model.NewLongUrl, cancellationToken);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var shortLink = await _shortLinkService.GetByIdAsync(id, cancellationToken);
            var model = new EditViewModel()
            {
                Id = shortLink.Id,
                OldLongUrl = shortLink.LongUrl,
                ShortUrl = shortLink.ShortUrl,
                CreatedAt = shortLink.CreatedAt,
                ClickCount = shortLink.ClickCount,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var shortLink = new ShortLink(model.NewLongUrl, model.ShortUrl, model.CreatedAt, model.ClickCount, model.Id);
                await _shortLinkService.UpdateAsync(shortLink, cancellationToken);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _shortLinkService.DeleteAsync(id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> IncrementClickCount(int id, CancellationToken cancellationToken)
        {
            await _shortLinkService.IncrementClickCountAsync(id, cancellationToken);

            var shortLink = await _shortLinkService.GetByIdAsync(id, cancellationToken);
            return Redirect(shortLink.LongUrl);
        }
    }
}
