using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIApplication.Models
{
	public interface CRUDOperationRepository
	{
		void AddProduct(Product product);

		IEnumerable<Product> DisplayPoduct();

		IEnumerable<Product> EditProduct(int id);

		void UpdateProduct(int id, Product product);

		void DeleteProduct(int id);
	}
}