using Maxim.DAL;
using Maxim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Maxim.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Service> Services = await _db.Services.Where(p => !p.IsDeleted).ToListAsync();
            return View(Services);
        }
    }
}