using Microsoft.EntityFrameworkCore;
using PRODUCT_MICROSERVICES.Models;

namespace PRODUCT_MICROSERVICES.DBContexts
{
    public class ProductContext: DbContext
    {


        public ProductContext(DbContextOptions<ProductContext> options) : base(options) 
        {

        }   

        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "asad",
                    Description = "Developer",
                },

                new Category
                {
                    Id = 2,
                    Name = "Waqas",
                    Description = "Developer"

                },

                new Category
                {
                    Id = 3,
                    Name = "Fatima",
                    Description = "Developer"

                }

                 );
            
        }
    }
}
