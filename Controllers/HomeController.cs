using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekti.Data;
using Projekti.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

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