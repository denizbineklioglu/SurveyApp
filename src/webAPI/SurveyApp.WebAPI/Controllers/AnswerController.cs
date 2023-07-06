using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Services;

namespace SurveyApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService answerService;

        public AnswerController(IAnswerService answerService)
        {
            this.answerService = answerService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAnswer(List<AnswerRequest> model)
        {
            await answerService.CreateAnswerAsync(model);
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAnswerIstatistics(int id)
        {
            var statistics = await answerService.GetIstatistic(id);
            if (statistics != null)
            {
                return Ok(statistics);
            }
            return BadRequest();
        }
    }
}
