using MVCApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    [Authorize]
    public  class ProductController : Controller
    {
        private string Base_URL = "http://localhost:57126/api/";

        

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product model)
        {
            try
            {

                HttpClient client = new HttpClient();
                var response =client.PostAsync("http://localhost:57126/api/Account/Register", new StringContent(JsonConvert.SerializeObject(model),Encoding.UTF8,"application/json")).Result;
                return RedirectToAction("Get");
            }catch(Exception e)
            {
                return null;
            }

        }

        public ActionResult Get()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("http://localhost:57126/api/Account/GetDetails").Result;

                if (response.IsSuccessStatusCode)
                {
                    var res= response.Content.ReadAsStringAsync().Result;
                    return View(JsonConvert.DeserializeObject<IEnumerable<Product>>(res));
                }
                   
                return null;
            }
            catch
            {
                return null;
            }
        }

        public ActionResult Edit(Product objProduct)
        {
           HttpClient clinet = new HttpClient();
          clinet.BaseAddress = new Uri(Base_URL); 
         //  clinet.PutAsync("Account/",new StringContent(JsonConvert.SerializeObject(objProduct),Encoding.UTF8,"application/json"));

           return View(objProduct);
        }
        [HttpPost]
        public ActionResult Update(Product objProduct)
        {
            HttpClient clinet = new HttpClient();
            clinet.BaseAddress = new Uri(Base_URL);
            clinet.PutAsync("http://localhost:57126/api/Account/PutDetails/", new StringContent(JsonConvert.SerializeObject(objProduct), Encoding.UTF8, "application/json"));
            return RedirectToAction("Get");
        }

        public async  Task<ActionResult> Delete(int id)
        {
            HttpClient clinet = new HttpClient();
            clinet.BaseAddress = new Uri(Base_URL);
            HttpResponseMessage response = await clinet.DeleteAsync("http://localhost:57126/api/Account/DeleteProduct/" + id);

            return RedirectToAction("Get");
        }
    }
}