using System.Collections.Generic;
using System.Threading.Tasks;
using Capstone_CarDealership.Models;
using CarDealershipApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarsDbContext _context;

        public CarsController(CarsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return _context.Cars;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return Created($"api/cars/{car.CarId}", car);
        }
    }
}
