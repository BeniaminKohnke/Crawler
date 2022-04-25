namespace Crawler
{
    public sealed record Product
    {
        public readonly string Sku;
        public long ProductId { get; private set; }
        public string Name { get; }
        public string Url { get; }

        public Product(string name, string url, string sku)
        {
            Name = name;
            Url = url;
            Sku = sku;
        }
    }
}
