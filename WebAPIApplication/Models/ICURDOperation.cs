using System.Collections.Generic;

namespace WebAPIApplication.Models
{
    public interface ICURDOperation
    {
        void AddProduct(Product product);
        void DeleteProduct(int id);
        IEnumerable<Product> DisplayPoduct();
        IEnumerable<Product> EditProduct(int id);
        void UpdateProduct(int id, Product product);
    }
}