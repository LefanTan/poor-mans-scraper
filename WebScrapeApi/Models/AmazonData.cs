namespace WebScrapeApi.Models
{
    public class AmazonData : IData
    {
        public string? Asin { get; set; }
        public string? Title { get; set; }
        public string? Price { get; set; }
        public string? ListPrice { get; set; }
        public string? SubscribePrice { get; set; }
        public string? Savings { get; set; }
        public string? Coupon { get; set; }
    }
}
