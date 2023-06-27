using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.Services;

namespace SurveyApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _service;

        public QuestionController(IQuestionService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateQuestionAsync(CreateQuestionRequest model)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateQuestionAsync(model);
                return Ok();
            }
            return BadRequest(ModelState);
        }

    }
}
