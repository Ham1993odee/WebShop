namespace WebShop
{
    internal class WebShopController
    {
        private IProduct products;

        public WebShopController(IProduct products)
        {
            this.products = products;
        }

        public void start()
        {
            while (true)
            {
                HuvudMeny();
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            GetAllProducts();
                            break;
                        case 2:
                            CreateProduct();
                            break;
                        case 3:
                            UpdateProduct();
                            break;
                        case 4:
                            DeleteProduct();
                            break;
                        case 5:
                            FindProduct();
                            break;
                        case 6:
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Your choice should be one of these numbers: 1, 2, 3, 4, 5, 6");
                            break;
                            
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Your choice should be one of these numbers: 1, 2, 3, 4, 5, 6");
                }
            }
        }

        private void FindProduct()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("insert name:");
                    string? name = Console.ReadLine();
                    CollectionProduct collectionProduct = products.FindProduct(name);
                    if (collectionProduct != null)
                    {
                        Console.WriteLine(collectionProduct.printCollectionProduct());
                    }
                    else
                    {
                        Console.WriteLine("Product " + name + " not found");
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void DeleteProduct()
        {
            try
            {
                Console.WriteLine("insert id:");
                int id = Convert.ToInt32(Console.ReadLine());
                if (products.DeleteProduct(id))
                {
                    Console.WriteLine("Product " + id.ToString() + " is deleted");
                }
                else
                {
                    Console.WriteLine("Product " + id.ToString() + " not found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("id should be a number");
            }
        }

        private void UpdateProduct()
        {
            try
            {
                Console.WriteLine("insert id:");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("insert new name:");
                string? name = Console.ReadLine();

                Console.WriteLine("insert new price:");
                try
                {
                    double price = Convert.ToDouble(Console.ReadLine());
                    if (products.UpdateProduct(id, name, price))
                    {
                        Console.WriteLine("Product " + id.ToString() + " is updated");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Price should be a number");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("id should be a number");
            }
        }

        private void CreateProduct()
        {
            try
            {
                Console.WriteLine("insert id:");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("insert new name:");
                string? name = Console.ReadLine();

                Console.WriteLine("insert new price:");
                try
                {
                    double price = Convert.ToDouble(Console.ReadLine());
                    products.CreateProduct(id, name, price);
                    Console.WriteLine("Product " + id.ToString() + " is created");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Price should be a number");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("id should be a number");
            }
        }

        private void GetAllProducts()
        {

            List<CollectionProduct>productsList = products.GetAllProducts();
            foreach(CollectionProduct product in productsList)
            {
                Console.WriteLine(product.printCollectionProduct());
            }
        }

        private void HuvudMeny()
        {
            Console.WriteLine("=========Webshop=========");
            Console.WriteLine("1. Get all products");
            Console.WriteLine("2. Create product");
            Console.WriteLine("3. Update product");
            Console.WriteLine("4. Delete product");
            Console.WriteLine("5. Find product");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Your choice:");
        }


    }
}
