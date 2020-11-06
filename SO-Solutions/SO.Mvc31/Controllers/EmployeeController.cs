using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SO.Mvc31.Controllers
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class EmployeeController : Controller
    {
        public EmployeeController()
        {

        }

        public async Task<IActionResult>  Login()
        {
            var emp = new Employee()
            {
                ID = 1,
                Name = "Vladimir Bacosa"
            };
            await EmpInput(emp);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EmpInput(Employee emp)
        {
            Console.WriteLine(emp.Name);
            return View();
        }
    }
}
