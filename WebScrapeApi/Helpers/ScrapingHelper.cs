using System.Text.RegularExpressions;
using Microsoft.Playwright;
using WebScrapeApi.Models;

namespace WebScrapeApi.Helpers;

public static class ScrapingHelper
{
    public static async Task<IData> ScrapeAmazon(IPage page, string url)
    {
        // Catch amazon url that isn't a PDP
        Regex asinRx = new Regex(
            @"[/dp/](?<asin>[A-Z0-9]{10})",
            RegexOptions.Compiled | RegexOptions.IgnoreCase
        );
        Match asinMatch = asinRx.Match(url);
        var asin = asinMatch.Groups["asin"].Value;
        if (asin == "")
            throw new BadHttpRequestException("Not a valid Amazon PDP page", 400);

        page.SetDefaultTimeout(1000);

        var productTitleText = await page.ExtractText("#productTitle");

        var priceText = await page.ExtractText(".priceToPay .a-offscreen");
        var priceAltText = await page.ExtractText(".apexPriceToPay .a-offscreen");

        var listPriceText = await page.ExtractText("[data-a-strike=true] .a-offscreen");
        var savingsText = await page.ExtractText(
            "#corePriceDisplay_desktop_feature_div .savingsPercentage"
        );
        var savingsAltText = await page.ExtractText(".a-span12.a-color-price .a-offscreen");

        var subscribePriceText = await page.ExtractText("#sns-base-price");
        var couponText = await page.ExtractText(
            "#promoPriceBlockMessage_feature_div .a-color-success"
        );

        // More Regex stuff
        Regex couponRx = new Regex(
            @"(?<couponPrice>\$?\d*\.?\d+%?)",
            RegexOptions.Compiled | RegexOptions.IgnoreCase
        );
        Match couponMatch = couponRx.Match(couponText);

        return new AmazonData
        {
            Asin = asin,
            Title = productTitleText,
            Price = priceText.NullIfEmpty() ?? priceAltText,
            ListPrice = listPriceText,
            Savings = savingsText.NullIfEmpty() ?? savingsAltText,
            SubscribePrice = subscribePriceText,
            Coupon = couponMatch.Groups["couponPrice"].Value
        };
    }

    public static async Task<string> ExtractText(this IPage page, string selector)
    {
        try
        {
            return await page.EvalOnSelectorAsync<string>(selector, "node => node.innerText");
        }
        catch (Exception)
        {
            return "";
        }
    }

    public static string? NullIfEmpty(this string s)
    {
        return string.IsNullOrEmpty(s) ? null : s;
    }
}
