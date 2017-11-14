using ASPNETKata.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using ASPNETKata.Shared;

namespace ASPNETKata.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductRepository repo;

		public ProductController(IProductRepository repo)
		{
			this.repo = repo;
		}
		
		public ActionResult Index()
		{
			var list = repo.GetProducts();
			return View(list);
		}
		
		public ActionResult Details(int id)
		{
			var product = repo.GetDetails(id);
			return View(product);
		}
		
		public ActionResult Create()
		{
			return View();
		}
		
		[HttpPost]
		public ActionResult Create(Product product)
		{
			repo.InsertProduct(product);
			return RedirectToAction("Index");
		}
		
		public ActionResult Edit(int id)
		{
			var product = repo.GetDetails(id);
			return View(product);
		}
		
		[HttpPut]
		public ActionResult Edit(int id, Product product)
		{
			product.ProductId = id;
			repo.UpdateProduct(product);
			return RedirectToAction("Index");
		}
		
		public ActionResult Delete(int id)
		{
			var product = repo.GetDetails(id);
			return View(id);
		}
		
		[HttpDelete]
		public ActionResult Delete(int id, Product product)
		{
			repo.DeleteProduct(id);
			return RedirectToAction("Index");
		}
	}
}