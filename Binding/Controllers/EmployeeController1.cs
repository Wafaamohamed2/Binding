using Binding.Models;
using Binding.Repository;
using Microsoft.AspNetCore.Mvc;
using MVC_1.Models;

namespace Binding.Controllers
{
    public class EmployeeController1 : Controller
    {
      //  FristEntity context = new FristEntity();

        IEmployeeRepository EmpRepo;
        IDepartmentRepository DeptRepo;

        public EmployeeController1(IDepartmentRepository deptrep , IEmployeeRepository emprep  )  //Injecting DepartmentRepository and EmployeeRepository
        {
            EmpRepo = emprep;
            DeptRepo = deptrep;
        }


        public IActionResult New()
        {
            ViewData["DeptList"] = DeptRepo.GetAll();
            return View("New");
        }

        public IActionResult SaveNew(Employee emp)
        {
            if (ModelState.IsValid) {
                // custom validation dept_id !=0
                if (emp.Dept_Id != 0) {

                 EmpRepo.Create(emp);
                EmpRepo.Save();
                return RedirectToAction("Index1"); 
                }
                else
                {

                   ModelState.AddModelError("Dept_Id", "Please select a department");
                }
               
            }
            ViewData["DeptList"] =DeptRepo.GetAll();
            return View("New" , emp); 
        }
        public IActionResult Index1()
        {
            return View("Index1",EmpRepo.GetAll());
        }

        public IActionResult Edit(int id) {

            Employee employee = EmpRepo.GetById(id);
            List<Department> departmentsList = DeptRepo.GetAll();

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

            var existingEmployee = new Employee();
            if (existingEmployee != null)
            {
                existingEmployee.Name = empViewModelcs.Name;
                existingEmployee.Salary = empViewModelcs.Salary;
                existingEmployee.Address = empViewModelcs.Address;
                existingEmployee.Image = empViewModelcs.Image;
                existingEmployee.Dept_Id = empViewModelcs.Dept_Id;
                existingEmployee.Id = empViewModelcs.Id;

               EmpRepo.Update(existingEmployee);
                EmpRepo.Save();
                return RedirectToAction("Index1");


            }
            // if employee not take name or name is empty then return to edit view
             empViewModelcs.DeptList =DeptRepo.GetAll();
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

