using Binding.Models;
using Binding.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_1.Models;

namespace Binding.Controllers
{
    public class DepartmentController : Controller
    {
        //  FristEntity context = new FristEntity();
        IEmployeeRepository EmpRepo;
        IDepartmentRepository DeptRepo;

        public DepartmentController(IEmployeeRepository employee , IDepartmentRepository department ) // Inject EmployeeRepository and DepartmentRepository
        {
            EmpRepo = employee;
            DeptRepo = department;
            
        }



        public IActionResult Index()
        {

            var departments = DeptRepo.GetAll();
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

              DeptRepo.Create(dept);
             DeptRepo.Save();  //save data in database

                //call Index method to show all departments then return it
                return RedirectToAction("Index");  // this is an action method call anthor action method

            }
    
             return View("New" , dept);
        }
    
    }
}
