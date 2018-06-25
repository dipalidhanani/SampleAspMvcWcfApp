using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SampleAspMvcWcfApp.Service
{
    [ServiceContract]
    interface IEmployeeService
    {
        [OperationContract]
        EmployeeResponce GetAllEmployee();

        [OperationContract]
        EmployeeResponce GetEmployeeByFirstName(string firstName);

        [OperationContract]
        void AddEmployee(AddEmployeeRequest request);
    }
}
