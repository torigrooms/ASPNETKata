using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETKata.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace ASPNETKata.Controllers
{
	public class ProductController : Controller
	{
		// GET: Product
		public ActionResult Index()
		{
			var connectionString = "Server=localhost;Database=Adventureworks;Uid=root;Pwd=Twins@2016";
			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				var list = conn.Query<Product>("SELECT * from Product ORDER BY ProductId DESC");
				return View(list);
			}
		}

		// GET: Product/Details/5
		public ActionResult Details(int id)
		{
			var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				var list = conn.Query<Product>("SELECT * from Product Where ProductId = @Id", new { Id = id });
				return View(list.FirstOrDefault());
			}
		}
		// GET: Product/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Product/Create
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			var name = collection["Name"];
			var connectionString = "Server=localhost;Database=Adventureworks;Uid=root;Pwd=password";
			using (var conn = new MySqlConnection(connectionString))

			{
				conn.Open();


				{
					// TODO: Add insert logic here
					conn.Execute("INSERT INTO product (Name) VALUES (@Name)", new { Name = name });
					return RedirectToAction("Index");
				}

			}

		}

		// GET: Product/Edit/5
		public ActionResult Edit(int id)
		{
			var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				var list = conn.Query<Product>("SELECT * from Product Where ProductId = @Id", new { Id = id });
				return View(list.FirstOrDefault());
			}
		}




		// POST: Product/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			var name = collection["Name"];

			var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

			using (var conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				conn.Execute("UPDATE product SET Name = @Name WHERE ProductId = @Id", new { Name = name, Id = id });
				return RedirectToAction("Index");
			}
		}

		// GET: Product/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Product/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{

			{
				var name = collection["Name"];

				var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

				using (var conn = new MySqlConnection(connectionString))
				{
					conn.Open();
					conn.Execute("DELETE FROM product WHERE productId = @Id", new { Id = id });
					return RedirectToAction("Index");
				}

			}

		}
	}
}