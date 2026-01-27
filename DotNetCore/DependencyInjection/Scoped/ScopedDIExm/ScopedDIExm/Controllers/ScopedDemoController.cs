using Microsoft.AspNetCore.Mvc;
using ScopedDIExm.ScopedTracker;

namespace ScopedDIExm.Controllers
{
    // Inject the service in a controller:
    public class ScopedDemoController : ControllerBase
    {
        private readonly IScopedRequestTracker _requestTracker1;
        private readonly IScopedRequestTracker _requestTracker2;

        //Here, the IScopedRequestTracker is injected into the controller,
        //and the DI system provides the same ScopedRequestTracker instance for the duration of the HTTP request
        public ScopedDemoController(IScopedRequestTracker requestTracker1, IScopedRequestTracker requestTracker2)
        {
            _requestTracker1 = requestTracker1;
            _requestTracker2 = requestTracker2;
        }

        [HttpGet("scoped-demo")]
        public IActionResult Get()
        {
            return Ok(new
            {
                Tracker1 = _requestTracker1.GetInstanceId(), //Each instance will have same value for a single http request
                Tracker2 = _requestTracker2.GetInstanceId()
            });
        }
    }
}
