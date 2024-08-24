using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineJobPortalMVC.Models;
using System.Text;

namespace OnlineJobPortalMVC.Controllers
{
    public class CityController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7077/api");
        private readonly HttpClient _httpClient;

        public CityController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            List<City> cityList = new List<City>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/City/GetAllCities").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                cityList = JsonConvert.DeserializeObject<List<City>>(data);
            }
            return View(cityList);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            City city = new City();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/City/GetCityByID/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                city = JsonConvert.DeserializeObject<City>(data);
            }

            return View(city);

        }

        [HttpPost]
        public IActionResult Edit(City city)
        {
            try
            {
                string data = JsonConvert.SerializeObject(city);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/State/UpdateState/" + city.CityID, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Details updated successfully";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            City city = new City();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/City/GetCityByID/" + Id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                city = JsonConvert.DeserializeObject<City>(data);

            }
            return View(city);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "/City/DeleteCity/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Details Deleted successfully";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
            }
            return View();
        }
    }
}
