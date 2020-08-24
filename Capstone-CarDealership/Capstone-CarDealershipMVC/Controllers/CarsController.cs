using System.Threading.Tasks;
using CarDealershipMVC.Models;
using CarDealershipMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipMVC.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService _service;

        public CarsController(ICarsService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Search(CarSearchModel car)
        {
            var model = await _service.Search(car);
            return View(model);
        }

        public ActionResult Post()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post(Car car)
        {
            if (ModelState.IsValid)
            {
                _service.Post(car);
                TempData["Success"] = $"Successfully added {car.Color} {car.Year} {car.Make} {car.Model} to the database!";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
