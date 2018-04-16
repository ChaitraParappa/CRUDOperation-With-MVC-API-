using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
    public class CURDOperation
    {
        public void AddProduct(Product product)
        {
            using (CustomerDbContext customerDbContext = new CustomerDbContext())
            {
                customerDbContext.Products.Add(product);
                customerDbContext.SaveChanges();
            }

        }

        public IEnumerable<Product> DisplayPoduct()
        {
            using (CustomerDbContext customerDbContext = new CustomerDbContext())
            {
                IEnumerable<Product> result = from p in customerDbContext.Products select p;

                return result;
            }
        }

        public IEnumerable<Product> EditProduct(int id)
        {
            using (CustomerDbContext customerDbContext = new CustomerDbContext())
            {
                IEnumerable<Product> result = from p in customerDbContext.Products.Where(x => x.id == id)
                                              select p;
                return result;
            }
           
                
            
        }

        public void UpdateProduct(int id,Product product)
        {
            using (CustomerDbContext customerDbContext = new CustomerDbContext())
            {
                Product products = customerDbContext.Products.Where(x => x.id == id).FirstOrDefault();
                products.name = product.name;
                products.description = product.description;
                products.price = product.price;
                customerDbContext.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            using (CustomerDbContext customerDbContext = new CustomerDbContext())
            {
                Product result = customerDbContext.Products.Find(id);
                customerDbContext.Products.Remove(result);
                customerDbContext.SaveChanges();
            }
        }
    }
}