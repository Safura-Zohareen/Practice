using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class EmpDataController : Controller
    {
        public ViewResult AllEmployees()
        {
            var context = new LntTrainingEntities();
            var model = context.EmpTables.ToList();
            return View(model);
        }

        public ViewResult Find(string id)
        {
            int empId = int.Parse(id);
            var context = new LntTrainingEntities();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpID == empId);
            return View(model);

        }
        //ActionResult is the abstract class for all kinds of action returns....
        [HttpPost]
        public ActionResult Find(EmpTable emp)
        {
            var context = new LntTrainingEntities();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpID == emp.EmpID);
            model.EmpName = emp.EmpName;
            model.EmpAddress = emp.EmpAddress;
            model.EmpSalary = emp.EmpSalary;
            context.SaveChanges();//Commits the changes made to the records...
            return RedirectToAction("AllEmployees");
        }

        public ViewResult NewEmployee()
        {
            var model = new EmpTable();//No Values in it...
            return View(model);
        }

        [HttpPost]
        public ActionResult NewEmployee(EmpTable emp)
        {
            var context = new LntTrainingEntities();
            context.EmpTables.Add(emp);
            context.SaveChanges();
            return RedirectToAction("AllEmployees");
        }

        public ActionResult Delete(string id)
        {
            //convert string to int
            int empId = int.Parse(id);
            var context = new LntTrainingEntities();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpID == empId);
            context.EmpTables.Remove(model);
            context.SaveChanges();
            return RedirectToAction("AllEmployees");
        }
    }
}