using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Data;
using EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Controllers
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
            throw new Exception();
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
