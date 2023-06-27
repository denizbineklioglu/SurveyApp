using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurveyApp.DataTransferObjects.Responses;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace SurveyApp.Mvc.Controllers
{
    public class SurveyController : Controller
    {
        
        public IActionResult GetSurveys()
        {
            var client = new HttpClient();
            var endpoint = "http://localhost:5035/api/Survey/GetList";
            var request = client.GetAsync(endpoint).Result;
            var response = request.Content.ReadAsStringAsync().Result;

            var value = JsonConvert.DeserializeObject<IEnumerable<SurveyListResponse>>(response);

            return View(value);
        }


        public  IActionResult GetSurveyQuestions(int id)
        {

            var client = new HttpClient();
            var endpoint = "http://localhost:5035/api/Survey/" + id;
            var request = client.GetAsync(endpoint).Result;
            var response = request.Content.ReadAsStringAsync().Result;

            var value = JsonConvert.DeserializeObject<IEnumerable<SurveyQuestionsListResponse>>(response);

            return View(value);
        }

        
    }
}
