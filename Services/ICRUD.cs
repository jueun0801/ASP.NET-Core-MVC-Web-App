using Assignment_12._1.Models;
namespace Assignment_12._1.Services
{
    public interface ICRUD      //2. Create 'Services' folder to add interface in ICRUD
    {
        List<Product> GetProducts();    
        Product GetProduct(int id);
        void AddProduct (Product product);
        void DeleteProduct (int id);
        void UpdateProduct (Product product);
        int GetMaxId();
    }
}
