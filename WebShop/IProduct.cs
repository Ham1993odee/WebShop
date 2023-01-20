namespace WebShop
{
    internal interface IProduct
    {
        public List<CollectionProduct> GetAllProducts();
        public void CreateProduct(int id, string name, double price);

        public bool UpdateProduct(int id, string name, double price);

        public CollectionProduct FindProduct(string name);

        public bool DeleteProduct(int id);
    }
}
