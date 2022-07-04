using Microsoft.AspNetCore.Mvc;
using Microsoft.Playwright;
using WebScrapeApi.Helpers;
using WebScrapeApi.Models;

namespace WebScrapeApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ScrapeController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ScrapeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("", Name = "scrape")]
        public async Task<ActionResult> ScrapeUrlAsync([FromQuery(Name = "url")] string urlString)
        {
            if (urlString == null)
            {
                return BadRequest(new { message = "url query param missing", });
            }

            var url = new Uri(urlString);

            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();
            var page = await browser.NewPageAsync();
            await page.GotoAsync(urlString);

            AmazonData result = (AmazonData)await ScrapingHelper.ScrapeAmazon(page, urlString);

            return Ok(result);
        }
    }
}
