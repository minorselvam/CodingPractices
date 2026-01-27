using Microsoft.AspNetCore.Mvc;
using TransientEx.TransientRequestTracker;

namespace TransientEx.Controllers
{
    public class TransientDemoController : Controller
    {
        private ITransientRequestTracker _tracker1;
        private ITransientRequestTracker _tracker2;

        //To verify that AddTransient is providing a new instance each time, you can inject the same service multiple times and
        //compare their identities. Since AddTransient always creates a new instance on each request,
        //the object references (or unique IDs) will differ.
        public TransientDemoController(ITransientRequestTracker tracker1, ITransientRequestTracker tracker2)
        {
            _tracker1 = tracker1;
            _tracker2 = tracker2;
        }

        //Expected Output:
        //When you call the endpoint, you will see that id1 and id2 are different, and sameInstance is false.
        //This proves that each injection of a transient service results in a new instance, even within the same request  

        [HttpGet("transient-demo")]
        public IActionResult Get()
        {
            var ID1 = _tracker1.GetInstanceID();
            var ID2 = _tracker2.GetInstanceID();

            return Ok(
                new
                {
                    ID1,
                    ID2,
                    SameInstance = ID1 == ID2
                });
        }
    }
}
