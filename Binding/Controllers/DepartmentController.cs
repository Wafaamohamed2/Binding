using Binding.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_1.Models;

namespace Binding.Controllers
{
    public class DepartmentController : Controller
    {
        FristEntity context = new FristEntity();

     
        public IActionResult Index()
        {

            var departments = context.departments.ToList();
            return View(departments);
        }


        // anchor tag .. open empty form
        [HttpGet] //default is get method of form || anchor tag
        public IActionResult New()
        {
            return View(); //form is empty
        }


        // submit button .. save data in Database
        [HttpPost] //default is post method of form || submit button
        public IActionResult SaveData (Department dept)
        {

            if (dept != null && !string.IsNullOrEmpty(dept.Name))
            {
                if (string.IsNullOrEmpty(dept.ManagerName))
                {
                    dept.ManagerName = "Default Manager";
                }

                context.departments.Add(dept);
                context.SaveChanges();

                //call Index method to show all departments then return it
                return RedirectToAction("Index");

            }
    
             return View("New");
        }
    
    }
}
