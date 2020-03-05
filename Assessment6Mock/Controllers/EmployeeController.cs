using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment6Mock.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assessment6Mock.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;
        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Employees()
        {
            var found = _context.Employee.ToList();
            return View(found);
        }
        public IActionResult RetirementInfo(int Id)
        {
            Employee found = _context.Employee.Find(Id);
            if(found.Age > 60)
            {
                ViewBag.CanRetire = true;
            }
            else
            {
                ViewBag.CanRetire = false;
            }
            ViewBag.Benefits = found.Salary * (decimal)0.6;
            return View();
        }
    }
}