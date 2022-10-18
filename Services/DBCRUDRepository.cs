using Assignment_12._1.Models;

namespace Assignment_12._1.Services
{
    //4. Create DBCRUDRepository in Services and implement ICRUD
    public class DBCRUDRepository : ICRUD   
    {
        //5. create variable of product context
        private ProductContext _productContext; //this variable will be used as a reference to the database

        //6. Create constructor and give the name of context and initialize it
        public DBCRUDRepository(ProductContext productContext)  //representation of database    //no new instances are created in web application
        {
            _productContext = productContext;
        }
        public void AddProduct(Product product)
        {
            _productContext.Products.Add(product);
            _productContext.SaveChanges();  //data is added in db
        }

        public void DeleteProduct(int id)
        {
            var prod = _productContext.Products.Find(id);
            if( prod != null)
            {
                _productContext.Products.Remove(prod);
                _productContext.SaveChanges();
            }
        }

        public int GetMaxId()
        {
            return _productContext.Products.Max(x => x.Id)+1;
        }

        public Product GetProduct(int id)
        {
            return _productContext.Products.Find(id);
        }

        public List<Product> GetProducts()
        {
            //return _productContext.Products.ToList<Product>();
            return new List<Product>(_productContext.Products);
        }

        public void UpdateProduct(Product product)
        {
            var prod = _productContext.Products.Find(product.Id);
            if(prod != null)
            {
                prod.Id= product.Id;
                prod.Name= product.Name;
                prod.Description= product.Description;
                prod.Price= product.Price;
                prod.ImageName= product.ImageName;
                _productContext.SaveChanges();
            }
        }
    }
}
