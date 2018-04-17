using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    public class AccountController : ApiController
    {
		CRUDOperationRepository _cURDOperation = new CURDOperation();

        [HttpPost]
        public void Register(Product model)
        {
            try
            {
				_cURDOperation.AddProduct(model);
                
            }catch(Exception e)
            {
                Content(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        
       [HttpGet]
        public IEnumerable<Product> GetDetails()
        {
            IEnumerable<Product> result = _cURDOperation.DisplayPoduct();
            return result;
        }

        [HttpGet]
        public IEnumerable<Product> GetDetails(int id)
        {
            IEnumerable<Product> result = _cURDOperation.EditProduct(id);
            return result;
        }
        
        [HttpPut]
        [Route("api/Account/PutDetails")]
        public void PutDetails(Product product)
        {
			_cURDOperation.UpdateProduct(product.id, product);
        }
        [HttpDelete]
        public void DeleteProduct(int id)
        {
			_cURDOperation.DeleteProduct(id);
        }
    }
}
