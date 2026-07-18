using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SingletonDotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly Interfaces.ILogger _logger;

        public ValuesController(Interfaces.ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string WriteLog()
        {
            _logger.LogMessage("Controller logging via singleton!");
            return "message logged";
        }
    }
}
