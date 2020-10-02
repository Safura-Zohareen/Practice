using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class ExampleController : Controller
    {
        // GET: Example
        public ActionResult Index()
        {
            var context = new LntTrainingEntities();
            var model = context.Customers.ToList();
            return View(model);
        }

        public ActionResult Find(string id)
        {
            var context = new LntTrainingEntities();
            var empid = int.Parse(id);
            var model = context.Customers.FirstOrDefault((c) => c.CustID == empid);
            return View(model);
        }

        [HttpPost]
        public ActionResult Find(Customer cst)
        {
            var context = new LntTrainingEntities();
            var model = context.Customers.FirstOrDefault((c) => c.CustID == cst.CustID);
            model.CustName = cst.CustName;
            model.CustAddress = cst.CustAddress;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddNew()
        {
            return View(new Customer());
        }

        [HttpPost]
        public ActionResult AddNew(Customer cst)
        {
            var context = new LntTrainingEntities();
            context.Customers.Add(cst);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            var context = new LntTrainingEntities();
            var empid = int.Parse(id);
            var model = context.Customers.FirstOrDefault((c) => c.CustID == empid);
            context.Customers.Remove(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}