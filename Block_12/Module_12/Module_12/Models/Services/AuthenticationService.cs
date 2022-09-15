using Module_12.Models.Employees;
using System.Collections.Generic;

namespace Module_12.Models.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService()
        {
        }

        public IEmployee AuthenticationEmployee { get; set; }

        public void Authenticate(IEmployee employee) => AuthenticationEmployee = employee;

        public IEnumerable<IEmployee> GetAll()
        {
            return new List<IEmployee> { new Manager(), new Consultant() };
        }
    }
}