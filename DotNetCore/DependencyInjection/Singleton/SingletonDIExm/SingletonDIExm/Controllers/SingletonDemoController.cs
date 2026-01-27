using Microsoft.AspNetCore.Mvc;
using SingletonDIExm.SingletonTracker;

namespace SingletonDIExm.Controllers
{
    public class SingletonDemoController : Controller
    {
        

        private readonly ISingletonTracker _requestTracker1;
        private readonly ISingletonTracker _requestTracker2;

        public SingletonDemoController(ISingletonTracker requestTracker1, ISingletonTracker requestTracker2)
        {
            _requestTracker1 = requestTracker1;
            _requestTracker2 = requestTracker2;
        }

        [HttpGet("singleton-demo")]
        public IActionResult Get()
        {
            return Ok(
                new
                {
                    Tracker1 = _requestTracker1.GetInstanceId(),
                    Tracker2 = _requestTracker2.GetInstanceId()
                });
        }

    }
}
