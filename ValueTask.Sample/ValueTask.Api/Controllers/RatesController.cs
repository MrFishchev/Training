using Microsoft.AspNetCore.Mvc;
using System;

namespace ValueTask.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatesController : ControllerBase
    {
        [HttpGet("{source}/{target}")]
        public IActionResult Get(string source, string target)
        {
            var rng = new Random();
            var value = new decimal(rng.NextDouble()); // don't use it

            return new JsonResult(new
            {
                source,
                target,
                rate = value
            });
        }
    }
}
