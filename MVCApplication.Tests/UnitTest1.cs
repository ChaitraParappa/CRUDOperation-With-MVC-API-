using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCApplication.Controllers;
using MVCApplication.Models;
using System.Web.Mvc;


namespace MVCApplication.Tests
{
	[TestClass]
	public class UnitTest1
	{
		ProductController ProductController = new ProductController();
		[TestMethod]
		public void AddProductWithSuccess()
		{
			Product obj = new Product
			{
				id = 1,
				name = "aa"

			};

			var result = ProductController.Update(obj) as RedirectToRouteResult;

			Assert.AreEqual("Get", result.RouteValues["action"]);
		}
	}
}
