using Binding.Models;
using Microsoft.AspNetCore.Mvc;
using MVC_1.Models;

namespace Binding.Controllers
{
    public class EmployeeController1 : Controller
    {
        FristEntity context = new FristEntity();


        public IActionResult New()
        {
            ViewData["DeptList"] = context.departments.ToList();
            return View("New");
        }

        public IActionResult SaveNew(Employee emp)
        {
            if (ModelState.IsValid) {
                // custom validation dept_id !=0
                if (emp.Dept_Id != 0) {

                 context.Employees.Add(emp);
                context.SaveChanges();
                return RedirectToAction("Index1"); 
                }
                else
                {

                   ModelState.AddModelError("Dept_Id", "Please select a department");
                }
               
            }
            ViewData["DeptList"] = context.departments.ToList();
            return View("New" , emp); 
        }
        public IActionResult Index1()
        {
            return View("Index1", context.Employees.ToList());
        }

        public IActionResult Edit(int id) {

            Employee employee = context.Employees.FirstOrDefault(e => e.Id == id);
            List<Department> departmentsList = context.departments.ToList();

            //-------create a new object of EmpDeptModel
            EmpDeptModel empViewModelcs = new EmpDeptModel();
            empViewModelcs.Id = employee.Id;
            empViewModelcs.Name = employee.Name;
            empViewModelcs.Salary = employee.Salary;
            empViewModelcs.Address = employee.Address;
            empViewModelcs.Image = employee.Image;
            empViewModelcs.Dept_Id = employee.Dept_Id;
            empViewModelcs.Department = employee.Department;

            empViewModelcs.DeptList = departmentsList;

            return View("Edit", empViewModelcs);
        }


        // Update Employee with new data
        [HttpPost]
        public IActionResult SaveEdit(EmpDeptModel empViewModelcs)
        {

            var existingEmployee = context.Employees.FirstOrDefault(e => e.Id == empViewModelcs.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = empViewModelcs.Name;
                existingEmployee.Salary = empViewModelcs.Salary;
                existingEmployee.Address = empViewModelcs.Address;
                existingEmployee.Image = empViewModelcs.Image;
                existingEmployee.Dept_Id = empViewModelcs.Dept_Id;

                context.SaveChanges();
                return RedirectToAction("Index1");


            }
            // if employee not take name or name is empty then return to edit view
             empViewModelcs.DeptList = context.departments.ToList();
             return View("Edit", empViewModelcs);
        }

        // Remote Attribute using Ajax Call
        public IActionResult checkName(string Name) {
            if (Name.Contains("Eg"))
                return Json(true);
            
            return Json(false);

        }

    }  
}

