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
                await _surveyService.CreateSurveyAsync(model);
                //
                return Ok();
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
    }
}
