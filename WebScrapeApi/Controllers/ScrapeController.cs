using Microsoft.AspNetCore.Mvc;
using Microsoft.Playwright;

namespace WebScrapeApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ScrapeController : ControllerBase
    {
        [HttpGet("", Name = "scrape")]
        public async Task<ActionResult> ScrapeUrlAsync([FromQuery(Name = "url")] string url)
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();
            var page = await browser.NewPageAsync();
            await page.GotoAsync(url);
            var button = await page.Locator("button >> nth=0").InnerHTMLAsync();

            var response = new { message = "Success", button };
            return Ok(response);
        }
    }
}
