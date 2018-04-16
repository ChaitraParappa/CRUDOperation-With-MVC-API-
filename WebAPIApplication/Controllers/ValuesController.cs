using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    public class ValuesController : ApiController
    {
        CURDOperation cURDOperation = new CURDOperation();
        // GET api/values
        public IEnumerable<Product> Get()
        {
            IEnumerable<Product> result = cURDOperation.DisplayPoduct();
            return result;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post(Product model)
        {
            cURDOperation.AddProduct(model);

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
