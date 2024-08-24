using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineJobPortalMVC.Models;
using System.Diagnostics.Metrics;
using System.Text;

namespace OnlineJobPortalMVC.Controllers
{
    public class CountryController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7077/api");
        private readonly HttpClient _httpClient;

        public CountryController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            List<Country> countryList = new List<Country>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Country/GetAllCountries").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                countryList = JsonConvert.DeserializeObject<List<Country>>(data);
            }
            return View(countryList);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Country country = new Country();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Country/GetCountryByID/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                country = JsonConvert.DeserializeObject<Country>(data);
            }

            return View(country);
            
        }

        [HttpPost]
        public IActionResult Edit(Country country)
        {
            try
            {
                string data = JsonConvert.SerializeObject(country);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/Country/UpdateCountry/" + country.CountryID, content).Result;

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
            Country country = new Country();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Country/GetCountryByID/" + Id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                country = JsonConvert.DeserializeObject<Country>(data);

            }
            return View(country);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            try
            {
                HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "/Country/DeleteCountry/" + id).Result;
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
