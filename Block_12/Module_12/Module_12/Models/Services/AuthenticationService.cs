using Module_12.Models.Employees;
using Module_12.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_12.Models.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        public IEmployee AuthenticationEmployee { get; set; }

        public void Authenticate(IEmployee employee) => AuthenticationEmployee = employee;

        public IEnumerable<IEmployee> GetAll()
        {
            return new List<IEmployee> { new Manager(), new Consultant() };
        }
    }
}