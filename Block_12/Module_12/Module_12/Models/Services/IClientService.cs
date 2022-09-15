using Module_12.Models.Dtos;
using Module_12.Models.Employees;
using System.Collections.Generic;

namespace Module_12.Models.Services
{
    internal interface IClientService
    {
        IEnumerable<ClientDto> GetClients();

        public IEmployee AuthenticationEmployee { get; }
    }
}