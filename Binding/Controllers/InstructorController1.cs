using Binding.Models;
using Microsoft.AspNetCore.Mvc;
using MVC_1.Models;

namespace Binding.Controllers
{
    public class InstructorController1 : Controller
    {
        FristEntity context = new FristEntity();
        public IActionResult Index()
        {
            var instructors = context.Instructor.ToList(); 

            return View(instructors);
        }

        public IActionResult New()
        {
            var departmentsList = context.departments.ToList();
            var viewModel = new InstDeptModel
            {
                DeptList = departmentsList
            };
            return View(viewModel);
        }

        public IActionResult SaveData(Instructor inst)
        {

            if (ModelState.IsValid)
            {
                context.Instructor.Add(inst);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            // If the model is invalid, return to the form with validation errors
            var departmentsList = context.departments.ToList();
            var viewModel = new InstDeptModel
            {
                Instructor_Name = inst.Instructor_Name,
                Courses = inst.Courses,
                DepartmentId = inst.DepartmentId,
                DeptList = departmentsList
            };
            return View("New", viewModel);
        }
    }
}
