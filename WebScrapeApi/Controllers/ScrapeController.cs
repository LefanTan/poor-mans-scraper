using Microsoft.AspNetCore.Mvc;

namespace WebScrapeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapeController : ControllerBase
    {
        [HttpGet("", Name = "scrape")]
        public ActionResult ScrapeUrl()
        {
            var response = new { message = "Success" };
            return Ok(response);
        }
    }
}
