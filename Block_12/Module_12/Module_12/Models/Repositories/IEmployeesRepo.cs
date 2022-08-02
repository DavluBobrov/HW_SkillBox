using Module_12.Models.Employees;
using System.Collections.Generic;

namespace Module_12.Models.Repositories
{
    internal interface IEmployeesRepo
    {
        public IEnumerable<IEmployee> GetEmployees();
    }
}