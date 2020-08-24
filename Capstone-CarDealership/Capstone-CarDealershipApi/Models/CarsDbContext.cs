using CarDealershipApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Capstone_CarDealership.Models
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
    }
}
