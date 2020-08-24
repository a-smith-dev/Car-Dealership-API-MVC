using CarDealershipMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealershipMVC.Services
{
    public interface ICarsService
    {
        Task<IEnumerable<Car>> GetAll();
        void Post(Car car);
        Task<IEnumerable<Car>> Search(CarSearchModel car);
    }
}
