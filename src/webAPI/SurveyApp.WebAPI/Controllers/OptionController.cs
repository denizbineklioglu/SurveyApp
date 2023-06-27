using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.Services;
using System.Runtime.CompilerServices;

namespace SurveyApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IOptionService _service;

        public OptionController(IOptionService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOption(CreateOptionRequest model)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateOptionAsync(model);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
