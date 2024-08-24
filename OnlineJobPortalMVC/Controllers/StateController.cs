using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineJobPortalMVC.Models;
using System.Text;

namespace OnlineJobPortalMVC.Controllers
{
    public class StateController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7077/api");
        private readonly HttpClient _httpClient;

        public StateController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            List<State> stateList = new List<State>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/State/GetAllStates").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                stateList = JsonConvert.DeserializeObject<List<State>>(data);
            }
            return View(stateList);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            State state = new State();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/State/GetStatesByID/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                state = JsonConvert.DeserializeObject<State>(data);
            }

            return View(state);

        }

        [HttpPost]
        public IActionResult Edit(State state)
        {
            try
            {
                string data = JsonConvert.SerializeObject(state);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/State/UpdateState/" + state.StateID, content).Result;

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
            State state = new State();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/State/GetStatesByID/" + Id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                state = JsonConvert.DeserializeObject<State>(data);

            }
            return View(state);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "/State/DeleteState/" + id).Result;
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
