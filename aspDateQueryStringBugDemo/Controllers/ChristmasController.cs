using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace aspDateQueryStringBugDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChristmasController : ControllerBase
    {
        private readonly ILogger<ChristmasController> _logger;

        public ChristmasController(ILogger<ChristmasController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult IsItChristmas(DateTime date)
        {
            if(date.Month == 12 && date.Day == 25)
            {
                return Ok("Yes!");
            }

            return Ok("No!");
        }
    }
}
