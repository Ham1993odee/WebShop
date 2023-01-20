namespace WebShop
{
    internal class CollectionProduct
    {
        public int id { get; set; }
        public string? name { get; set; }
        public double price { get; set; }

        public CollectionProduct(int id, string? name, double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }

        public string printCollectionProduct()
        {
            return "Product: " + id.ToString() + " " + name + " " + price.ToString();
        }
    }
}
