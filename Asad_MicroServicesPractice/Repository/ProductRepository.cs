using PRODUCT_MICROSERVICES.DBContexts;
using PRODUCT_MICROSERVICES.Models;
using System.Collections.Generic;
using System.Linq;

namespace PRODUCT_MICROSERVICES.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _DbContext;

        public ProductRepository(ProductContext DbContext)
        {
            _DbContext = DbContext;  
        }

        public IEnumerable<Products> GetProducts()
        {
            return _DbContext.Products.ToList();
        }
        public Products GetProductsByID(int ProductId)
        {
            return _DbContext.Products.Find(ProductId);
        }
        public void UpdateProduct(Products Product)
        {
           _DbContext.Products.Update(Product);
            Save();
        }
        public void DeleteProduct(int ProductId)
        {
            var product = _DbContext.Products.Find(ProductId);
            _DbContext.Products.Remove(product);
            Save();
        }
        public void InsertProduct(Products Product)
        {
            _DbContext.Add(Product);
            Save();
        }
        public void Save()
        {
            _DbContext.SaveChanges();
        }

    }
}
