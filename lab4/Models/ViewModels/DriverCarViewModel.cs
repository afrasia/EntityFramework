using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models.ViewModels
{
    public class DriverCarViewModel
    {
        public IEnumerable<Driver> Drivers { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}