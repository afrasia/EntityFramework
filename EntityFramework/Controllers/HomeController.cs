using EntityFramework.Data;
using EntityFramework.Models;
using EntityFramework.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EntityFramework.Controllers
{
    public class HomeController : Controller
    {
        private readonly DrivingDbContext _context;

        public HomeController(DrivingDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            IQueryable<DriverCarGroupData> data =
                from car in _context.Cars
                group car by car.DriverID into dateGroup
                select new DriverCarGroupData()
                {
                    DriverName = _context.Drivers.Where(d => d.ID == dateGroup.Key).Single().LastName,
                    CarCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }
    }
}