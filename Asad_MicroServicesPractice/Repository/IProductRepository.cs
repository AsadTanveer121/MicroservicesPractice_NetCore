using PRODUCT_MICROSERVICES.Models;
using System.Collections.Generic;

namespace PRODUCT_MICROSERVICES.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetProducts();
      
        Products GetProductsByID(int ProductId);
        void UpdateProduct(Products Product);
        void DeleteProduct(int ProductId);
        void InsertProduct(Products Product);
        void Save();



    }
}
