using Maxim.Areas.Manage.Models.Services;
using Maxim.DAL;
using Maxim.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maxim.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles ="Admin")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _db;

        public ServiceController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Service> Services = await _db.Services.Where(s=>!s.IsDeleted).ToListAsync();
            return View(Services);
        }
        public IActionResult Create() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceVm vm) 
        { 
            if(!ModelState.IsValid) return View(vm);
            Service service = new Service()
            {
                Icon= vm.Icon,
                Title= vm.Title,
                Description= vm.Description,
                CreatedAt= DateTime.UtcNow,
            };
            _db.Services.Add(service);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index),"Service");
        }
        public async Task<IActionResult> Update(int id)
        {
            Service service = await _db.Services.Where(s => !s.IsDeleted && s.Id == id).FirstOrDefaultAsync();
            UpdateServiceVm vm = new UpdateServiceVm()
            {
                Id = id,
                Icon= service.Icon,
                Title= service.Title,
                Description= service.Description,
                CreatedAt = service.CreatedAt,
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateServiceVm vm)
        {
            if(!ModelState.IsValid) return View(vm);
            Service service = await _db.Services.Where(s => !s.IsDeleted && s.Id == vm.Id).FirstOrDefaultAsync();
            service.Icon = vm.Icon;
            service.Title = vm.Title;
            service.Description = vm.Description;
            service.UpdatedAt = DateTime.UtcNow;
            _db.Services.Update(service);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Service");
        }
        public async Task<IActionResult> Delete(int id)
        {
            Service service = await _db.Services.Where(s=>s.Id == id).FirstOrDefaultAsync();
            service.IsDeleted = true;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Service");
        }

    }
}
