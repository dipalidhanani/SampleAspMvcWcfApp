using SampleAspMvcWcfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SampleAspMvcWcfApp.Service;

namespace SampleAspMvcWcfApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Login"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            using (var client = new WcfHost.EmployeeService.EmployeeServiceClient())
            {
                var item = client.GetAllEmployee();
                List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(item.JsonResult);
                return View(employees);
            }

        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session["Login"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Employee employee)
        {
            if (ModelState.IsValid)
            {
                using (var client = new WcfHost.EmployeeService.EmployeeServiceClient())
                {
                    AddEmployeeRequest addEmployeeRequest = new AddEmployeeRequest();
                    addEmployeeRequest.Lastname = employee.Lastname;
                    addEmployeeRequest.Firstname = employee.Firstname;
                    addEmployeeRequest.Title = employee.Title;
                    addEmployeeRequest.Titleofcourtesy = employee.Titleofcourtesy;
                    addEmployeeRequest.Birthdate = employee.Birthdate;
                    addEmployeeRequest.Hiredate = employee.Hiredate;
                    addEmployeeRequest.Address = employee.Address;
                    addEmployeeRequest.City = employee.City;
                    addEmployeeRequest.Region = employee.Region;
                    addEmployeeRequest.Postalcode = employee.Postalcode;
                    addEmployeeRequest.Country = employee.Country;
                    addEmployeeRequest.Phone = employee.Phone;
                    addEmployeeRequest.Mgrid = employee.Mgrid;
                    client.AddEmployee(addEmployeeRequest);
                }
            }
            return View(employee);
        }

        [HttpPost]
        public ActionResult Login(Employee employee)
        {
            if (ModelState.IsValid)
            {
                using (var client = new WcfHost.EmployeeService.EmployeeServiceClient())
                {
                    var item = client.GetEmployeeByFirstName(employee.Firstname);
                    Employee employees = JsonConvert.DeserializeObject<Employee>(item.JsonResult);
                    if (employee.City == employees.City)
                    {
                        Session["Login"] = employee;
                        var i = Session["Login"] as Employee;
                        return RedirectToAction("Index");
                    }
                    return View(employee);
                }
            }
            return View(employee);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}