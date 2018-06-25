using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SampleData.DAC;
using Newtonsoft.Json;
using SampleData;

namespace SampleAspMvcWcfApp.Service
{

    class EmployeeService : IEmployeeService
    {
        private EmployeeDAC employeeDAC = new EmployeeDAC();

        public EmployeeResponce GetAllEmployee()
        {
            var responce = new EmployeeResponce();
            responce.JsonResult = JsonConvert.SerializeObject(employeeDAC.GetAllEmployee());
            return responce;
        }

        public EmployeeResponce GetEmployeeByFirstName(string firstName)
        {
            var responce = new EmployeeResponce();
            responce.JsonResult = JsonConvert.SerializeObject(employeeDAC.GetEmployeeByFirstName(firstName));
            return responce;
        }

        public void AddEmployee(AddEmployeeRequest request)
        {
            Employee employee = new Employee();
            employee.lastname = request.Lastname;
            employee.firstname = request.Firstname;
            employee.title = request.Title;
            employee.titleofcourtesy = request.Titleofcourtesy;
            employee.birthdate = request.Birthdate;
            employee.hiredate = request.Hiredate;
            employee.address = request.Address;
            employee.city = request.City;
            employee.region = request.Region;
            employee.postalcode = request.Postalcode;
            employee.country = request.Country;
            employee.phone = request.Phone;
            employee.mgrid = request.Mgrid;
            var responce = new EmployeeResponce();
            employeeDAC.AddEmployee(employee);
        }
    }
}
