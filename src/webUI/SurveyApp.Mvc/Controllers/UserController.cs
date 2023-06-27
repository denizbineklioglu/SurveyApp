using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using System.Text;

namespace SurveyApp.Mvc.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AppUserRegisterRequest model)
        {
            var client = new HttpClient();
            var value = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(value, Encoding.UTF8, "application/json");
            var endpoint = "http://localhost:5035/api/User/Register/";
            var request = client.PostAsync(endpoint,stringContent).Result;

            if (request.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }
            
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
