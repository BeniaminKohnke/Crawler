namespace Crawler
{
    public sealed record Product
    {
        public readonly string Sku;
        public string Name { get; }
        public string Url { get; }
        public decimal CurrentPrice { get; }
        public decimal OldPrice { get; }

        public Product(string name, string url, string sku, decimal currentPrice, decimal oldPrice)
        {
            Name = name;
            Url = url;
            Sku = sku;
            CurrentPrice = currentPrice;
            OldPrice = oldPrice;
        }
    }
}
