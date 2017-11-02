using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETKata.Models;

namespace ASPNETKata.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
	        var list = new List<Person>();
			list.Add(new Person {Age = 21, IsMinor = false, Name = "Josh"});
	        list.Add(new Person { Age = 3, IsMinor = true, Name = "Michael" });
	        list.Add(new Person { Age = 17, IsMinor = true, Name = "Sasha" });
	        list.Add(new Person { Age = 60, IsMinor = false, Name = "Lilah" });
	        list.Add(new Person { Age = 20, IsMinor = false, Name = "Penelope" });
	        list.Add(new Person { Age = 35, IsMinor = false, Name = "Jonah" });
	        list.Add(new Person { Age = 12, IsMinor = true, Name = "MaKai" });
	        list.Add(new Person { Age = 79, IsMinor = false, Name = "Lela" });
	        list.Add(new Person { Age = 1, IsMinor = true, Name = "Andy" });
	        list.Add(new Person { Age = 23, IsMinor = false, Name = "Val" });
			return View(list);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
