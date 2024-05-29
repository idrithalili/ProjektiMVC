using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekti.Data;
using Projekti.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Linq;

namespace Projekti.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Libra.Include(l => l.Autore).Include(l => l.ShtepiBotuese).Include(l => l.Zhanri);
            return View(await applicationDbContext.ToListAsync());
            //return View();
        }

        public async Task<IActionResult> SelectGenres()
        {
            var genres = await _context.Zhanre.ToListAsync();
            var viewModel = new UserPreferencesViewModel
            {
                Genres = genres,
                SelectedGenreIds = new List<int>()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SavePreferences(UserPreferencesViewModel model)
        {
            var selectedGenres = model.SelectedGenreIds;
            var serializedGenres = JsonConvert.SerializeObject(selectedGenres);
            CookieOptions option = new CookieOptions
            {
                Expires = System.DateTime.Now.AddDays(30)
            };
            Response.Cookies.Append("ZhanrePerdoruesi", serializedGenres, option);

            return RedirectToAction("ShowPreferences");
        }

        public async Task<IActionResult> ShowPreferences()
        {
            if (Request.Cookies.TryGetValue("ZhanrePerdoruesi", out string serializedGenres))
            {
                var genreIds = JsonConvert.DeserializeObject<List<int>>(serializedGenres);
                var books = await _context.Libra
                    .Include(l => l.Autore)
                    .Include(l => l.Zhanri)
                    .Where(b => genreIds.Contains((int)b.ZhanriId))
                    .ToListAsync();

                return View(books);
            }

            return View(new List<Libra>());
        }

        public IActionResult Menaxhimi()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}