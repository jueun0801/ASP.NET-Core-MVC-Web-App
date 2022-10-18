using Microsoft.EntityFrameworkCore;

namespace Assignment_12._1.Models
{
    //class representing db
    public class ProductContext:DbContext   //connection with the database is established with DbContext!
    {
        //1. provide a constructor
        public ProductContext(DbContextOptions<ProductContext> options):base(options)   //base keyword is used to call the base class constructor which in this case is DbContext
        {

        }
        //2. Add table(s)
        public DbSet<Product>? Products { get; set; }//product table

        //3.data seeding (creating dummy records) as needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder); //by default a blank table will be provided.
            modelBuilder.Entity<Product>().HasData(
                new Product { Id= 1, Name ="Toaster", Description = "4 slot toaster", ImageName ="toaster.jpg", Price = 40 },
                new Product { Id = 2, Name = "Kettle", Description = "Electric kettle", ImageName = "kettle.jpg", Price = 22 }

                );
        }
       
       
    }
}
