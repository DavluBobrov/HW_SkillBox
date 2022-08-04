using Module_12.Models.Employees;
using System.Collections.Generic;

namespace Module_12.Models.Services
{
    internal interface IAuthenticationService
    {
        IEmployee AuthenticationEmployee { get; }

        IEnumerable<IEmployee> GetAll();

        void Authenticate(IEmployee employee);
    }
}