using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebApiPractices
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost("{pageNumber?}")]
        public IActionResult GetValues([FromBody] ICollection<string> items,
            string pageNumber = "1", //accept as string to validate
            [FromQuery] string count = "3",
            [FromQuery] string sortOrder = "None"
            )
        {
            //validate inputs
            var invalidInputs = new List<string>();

            //validate pageNumber
            if(!int.TryParse(pageNumber, out int pageNum) || pageNum == 0)
            {
                invalidInputs.Add("Page Number");
            }

            //validate count
            if(!int.TryParse(count, out int countVal) || countVal == 0)
            {
                invalidInputs.Add("Count");
            }

            if(invalidInputs.Any())
            {
                return BadRequest(
                    new
                    {
                        message = "invalid inputs",
                        invalidParameters = invalidInputs
                    }
                );
            }

            if(items==null || !items.Any()) {
                return BadRequest(
                    new
                    {
                        message = "No items provided"
                    }
                );
            }


            return Ok();
        }

    }
}
