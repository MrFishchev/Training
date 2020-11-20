using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DockerTraining.Interfaces;

namespace DockerTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private readonly ISender _sender;

        public record ValueRequest(string Value);

        public ValueController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllValues()
        {
            var result = await _sender.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewValue([FromBody] ValueRequest request)
        {
            var result = await _sender.SaveOne(request.Value);
            if (result) return Ok();
            return Problem();
        }
    }
}
