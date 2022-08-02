using Module_12.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_12.Models.Repositories
{
    internal class EmployeesRepo : IEmployeesRepo
    {
        public EmployeesRepo()
        {
            InitEmployees();
        }

        private void InitEmployees()
        {
            List<IEmployee> employees = new();
            employees.Add(new Manager());
            employees.Add(new Consultant());
            Employees = employees;
        }

        private List<IEmployee> Employees { get; set; }

        public IEnumerable<IEmployee> GetEmployees() => Employees;
    }
}