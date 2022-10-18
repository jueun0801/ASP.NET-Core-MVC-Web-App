using Assignment_12._1.Models;

namespace Assignment_12._1.Services
{
    public class ProductRepository : ICRUD  //Step 3. Add ProductRepository class in 'Services' to implement interface
    {
        private List<Product> products;
        public ProductRepository()  // Add 'images' folder in wwwroot for product images
        {
            products = new List<Product>();
            products.Add(new Product() { Id = 1, Name = "Toaster", Description = "4 slot toaster", Price = 60, ImageName = "toaster.jpg" });
            products.Add(new Product() { Id = 2, Name = "Air Fryer", Description = "Roasts, reheats, meals", Price = 100, ImageName = "airfryer.jpg" });
            products.Add(new Product() { Id = 3, Name = "Crock Pot", Description = "Slow Cooker", Price = 40, ImageName = "crockpot.jpg" });
            products.Add(new Product() { Id = 4, Name = "Electric Kettle", Description = "Hot water boiler", Price = 30, ImageName = "kettle.jpg" });
        }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DeleteProduct(int id)
        {
            var prod = products.Find(x => x.Id == id);
            if(prod != null)
            products.Remove(prod);
        }

        public int GetMaxId()
        {
            int id = products.Max(x => x.Id);
            return id + 1;
        }

        public Product GetProduct(int id)   
        {
            if(id == null)
            {
                return null;
            }
            else
            {
                return products.Find(x => x.Id == id);
            }
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void UpdateProduct(Product product)
        {
            var prod = products.Find(x=> x.Id == product.Id);   
            if(prod != null)
            {
                prod.Id = product.Id;
                prod.Name = product.Name;
                prod.Description = product.Description;
                prod.Price = product.Price;
                prod.ImageName = product.ImageName;
            }
        }
    }
}
