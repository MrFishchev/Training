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

        public ValueController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public Task GetAllValues()
        {
            return _sender.GetAll();
        }

        [HttpPost]
        public Task AddNewValue([FromBody]string value)
        {
            return _sender.SaveOne(value);
        }
    }
}
