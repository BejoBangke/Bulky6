using Microsoft.AspNetCore.Mvc;
using Prototype6.Models;
using System.Diagnostics;

namespace Prototype6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISpecRepository _repository;

        public HomeController(ILogger<HomeController> logger, ISpecRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Spec()
        {
            var spec = await _repository.GetAll();
            return View(spec);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Spec spec)
        {
            if (ModelState.IsValid)
            {
                await _repository.Create(spec);
                return RedirectToAction(nameof(Spec));
            }

            return View(spec);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var spec = await _repository.GetById(id);

            if (spec == null)
            {
                return NotFound();
            }

            return View(spec);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Spec spec)
        {
            if (id != spec.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _repository.Update(spec);
                return RedirectToAction(nameof(Spec));
            }

            return View(spec);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var spec = await _repository.GetById(id);

            if (spec == null)
            {
                return NotFound();
            }

            return View(spec);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Spec spec)
        {
            await _repository.Delete(id);
            return RedirectToAction(nameof(Spec));
        }

    }
}
