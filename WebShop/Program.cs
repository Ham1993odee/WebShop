namespace WebShop
{
    internal class program
    {
        
        static void Main(string[] args)
        {
            IProduct products = new Product("mongodb+srv://¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤@cluster0.vonmo4j.mongodb.net/?retryWrites=true&w=majority", "WebShop");
            WebShopController webshop = new WebShopController(products);
            webshop.start();
            
        }
    }
}