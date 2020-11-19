using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace DockerTraining.GuidGeneratorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IConnectionMultiplexer _redis;
        private const string SetName = "DockerTraining";
        private readonly RedisKey RedisSetKey = new RedisKey(SetName);

        public StorageController(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllValues()
        {
            var values = await _redis.GetDatabase()?.SetMembersAsync(RedisSetKey);
            return Ok(values.Select(v => (string) v));
        }

        [HttpPost]
        public async Task<IActionResult> AddValue([FromBody] string value)
        {
            var redisValue = new RedisValue(value);
            var isSuccess = await _redis.GetDatabase()?.SetAddAsync(RedisSetKey, redisValue);

            if (isSuccess) return Ok();
            return Problem();
        }
    }
}
