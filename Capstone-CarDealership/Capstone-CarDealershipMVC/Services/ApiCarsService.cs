using CarDealershipMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CarDealershipMVC.Services
{
    public class ApiCarsService : ICarsService
    {
        private readonly HttpClient _client;

        public ApiCarsService(HttpClient client)
        {
            _client = client;
        }

        [HttpPost]
        public async void Post(Car car)
        {
            await _client.PostAsJsonAsync<Car>($"cars", car);
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _client.GetFromJsonAsync<IEnumerable<Car>>($"cars");
        }

        public async Task<IEnumerable<Car>> Search(CarSearchModel carSearch)
        {
            var carList = new List<Car>();

            if (carSearch.GetType().GetProperties().All(c => c.GetValue(carSearch) == null))
            {
                return carList;
            }

            var cars = await GetAll();

            carList.AddRange(cars
                .Where(x => carSearch.Make == null || x.Make.Contains(carSearch.Make, StringComparison.OrdinalIgnoreCase))
                .Where(x => carSearch.Model == null || x.Model.Contains(carSearch.Model, StringComparison.OrdinalIgnoreCase))
                .Where(x => carSearch.Year == null || x.Year == carSearch.Year)
                .Where(x => carSearch.Color == null || x.Color.Contains(carSearch.Color, StringComparison.OrdinalIgnoreCase)));

            return carList;
        }
    }
}
