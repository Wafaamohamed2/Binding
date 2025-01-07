using Binding.Models;
using Microsoft.AspNetCore.Mvc;

namespace Binding.Controllers
{
    [Route("BindController1")]

    public class BindController1 : Controller
    {

        //Model Binding : Map Action parameters with the request data   (Form Data , Query String , Rpute Data)
        // Bind permitiv type
        //Bind/BindController1/TestPrimitiv?id=1&name=Ahmed&age=25  "get" method
        //Bind/BindController1/TestPrimitiv/7?name=Ahmed&age=25     the id passed in the route data
        //Bind/BindController1/TestPrimitiv/7?name=Ahmed&age=25&color=red&color=blue&color=green

        [HttpGet("TestPrimitiv")]
        public IActionResult TestPrimitiv(int id, string name, int age , string[] color) 
        {

            return Content($"name = {name} , id = {id}");
        }


        //Bind Collection Type (Dectionary)
        //Bind/BindController1/TestCollection?phones[home]=123456&phones[work]=789456&name=Ahmed
        public IActionResult TestCollection(Dictionary<string, int> phones , string name)
        {
            return Content($"name = {name} ");
        }

        //Bind Complex / Custom Type

        //Bind/BindController1/TestComplex?id=1&name=Ahmed&age=25

        public IActionResult TestComplex(
           // [Bind (include: "id ,Name")]  // will take only the id and name
            Department department)
        {
            return Content("OK");
        }
    }
}
