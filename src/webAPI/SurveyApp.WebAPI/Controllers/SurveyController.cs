using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Services;
using System.Runtime.CompilerServices;

namespace SurveyApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSurvey(CreateSurveyRequest model)
        {
            if (ModelState.IsValid)
            {                
                var lastID = await _surveyService.CreateSurveyAsync(model);
                var url = "https://localhost:44350/Survey/" + lastID;
                return Ok(url);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public IActionResult GetSurveyQuestions(int id)
        {
            var values = _surveyService.GetSurveyQuestions(id);
            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var values = await _surveyService.GetSurveyList();
            return Ok(values);
        }


        [HttpGet("[action]")]

        public async Task<IActionResult> GetSurveysStatistic()
        {
            var statistics = await _surveyService.GetSurveyStatisticResponses();
            if (statistics != null)
            {
                return Ok(statistics);
            }
            return BadRequest();
        }
    }
}
