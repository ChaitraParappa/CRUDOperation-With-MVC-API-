using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCApplication.Controllers;
using MVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCApplication.Tests
{
	[TestClass]
	public class ProductControllerTests
	{
		ProductController ProductCo = new ProductController();
		[TestMethod]
		public void AddProductWithSuccess()
		{
			Product obj = new Product
			{
				id = 1,
				name = "aa"

			};

			var result = ProductCo.Update(obj) as RedirectToRouteResult;

			Assert.AreEqual("Get", result.RouteValues["action"]);
		}
	}
}
