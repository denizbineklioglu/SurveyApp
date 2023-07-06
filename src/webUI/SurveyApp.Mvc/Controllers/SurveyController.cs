using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Context;
using System.Collections;
using System.Net.Http.Json;
using System.Text;
using static System.Net.WebRequestMethods;

namespace SurveyApp.Mvc.Controllers
{
    public class SurveyController : Controller
    {
        private readonly SurveyAppContext _context;

        public SurveyController(SurveyAppContext context)
        {
            _context = context;
        }

        [Route("/Surveys")]
        public IActionResult GetSurveys()
        {
            var client = new HttpClient();
            var endpoint = "http://localhost:5035/api/Survey/GetList";
            var request = client.GetAsync(endpoint).Result;
            var response = request.Content.ReadAsStringAsync().Result;

            var value = JsonConvert.DeserializeObject<IEnumerable<SurveyListResponse>>(response);

            return View(value);
        }

        [Route("Survey/{id}")]
        [HttpGet]        
        public  IActionResult CreateAnswer(int id)
        {

            var client = new HttpClient();
            var endpoint = "http://localhost:5035/api/Survey/" + id;
            var request = client.GetAsync(endpoint).Result;
            var response = request.Content.ReadAsStringAsync().Result;

            var value = JsonConvert.DeserializeObject<SurveyQuestionsListResponse>(response);

            ViewBag.id = id;
            return View(value);
        }

        [Route("Survey/{id}")]
        [HttpPost]
        public IActionResult CreateAnswer(SurveyQuestionsListResponse model)
        {
            List<AnswerRequest> answers = new List<AnswerRequest>();
            for (int i = 0; i < model.Options.Count; i++)
            {
                IQueryable<int> questionID = _context.Options.Where(x => x.OptionID == model.Options[i].OptionID).Select(x => x.QuestionID);
                List<int> qr = questionID.ToList();
                int[] arrayint = questionID.ToArray();
                AnswerRequest answer = new AnswerRequest
                {
                    OptionID = model.Options[i].OptionID,
                    QuestionID = arrayint[0],
                    SurveyID = model.SurveyID
                };
                answers.Add(answer);
            }

            var client = new HttpClient();
            var value = JsonConvert.SerializeObject(answers);
            StringContent stringContent = new StringContent(value, Encoding.UTF8, "application/json");
            var endpoint = "https://localhost:7006/api/Answer/CreateAnswer";
            var request = client.PostAsync(endpoint, stringContent).Result;

            if (request.IsSuccessStatusCode)
            {
                return RedirectToAction("GetSurveys");
            }
            
            return RedirectToAction("CreateAnswer");
        }

        [Route("Survey/[action]")]
        [HttpGet]
        public IActionResult Istatistics()
        {

            var client = new HttpClient();
            var endpoint = "http://localhost:5035/api/Survey/GetSurveysStatistic";
            var request = client.GetAsync(endpoint).Result;
            var response = request.Content.ReadAsStringAsync().Result;

            var value = JsonConvert.DeserializeObject<IEnumerable<SurveyStatisticResponse>>(response);

            return View(value);
        }

        [Route("Survey/[action]/{id}")]
        [HttpGet]
        public IActionResult AnswerIstatistics(int id)
        {
            var client = new HttpClient();
            var endpoint = "https://localhost:7006/api/Answer/GetAnswerIstatistics?id=" + id;
            var request = client.GetAsync(endpoint).Result;
            var response = request.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<IEnumerable<IstatisticRequest>>(response);


            return View(value);
        }
    }
}
    
