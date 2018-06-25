using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData.DAC
{
    public class EmployeeDAC 
    {
        public EmployeeDAC()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }
        private TSQL2018Entities db = new TSQL2018Entities();

        public List<Employee> GetAllEmployee()
        {
            List<Employee> employee = new List<Employee>();
            employee = db.Employees.ToList();
            employee.ForEach(x => x.Employees1 = null);
            return employee;
        }

        public Employee GetEmployeeByFirstName(string firstName)
        {
            Employee employee = new Employee();
            employee = db.Employees.Where(x => x.firstname == firstName).FirstOrDefault();
            if(employee != null)
            {
                employee.Employees1 = null;
            }
            
            return employee; 
        }

        public void AddEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }
    }
}
