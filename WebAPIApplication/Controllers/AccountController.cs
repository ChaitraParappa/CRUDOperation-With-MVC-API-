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
        CURDOperation cURDOperation = new CURDOperation();

        [HttpPost]
        public IHttpActionResult Register(Product model)
        {
            try
            {
                cURDOperation.AddProduct(model);
                
            }catch(Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.ToString());
            }
        }

        
       [HttpGet]
        public IEnumerable<Product> GetDetails()
        {
            IEnumerable<Product> result = cURDOperation.DisplayPoduct();
            return result;
        }

        [HttpGet]
        public IEnumerable<Product> GetDetails(int id)
        {
            IEnumerable<Product> result = cURDOperation.EditProduct(id);
            return result;
        }
        
        [HttpPut]
        [Route("api/Account/PutDetails")]
        public void PutDetails(Product product)
        {
          cURDOperation.UpdateProduct(product.id, product);
        }
        [HttpDelete]
        public void DeleteProduct(int id)
        {
            cURDOperation.DeleteProduct(id);
        }
    }
}
