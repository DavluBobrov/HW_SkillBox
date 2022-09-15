using Module_12.Models.Dtos;
using Module_12.Models.Employees;
using Module_12.Models.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Module_12.Models.Services
{
    internal class ClientService : IClientService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IEmployeesRepo _userRepository;
        private readonly IClientsRepo _clientRepository;
        public IEmployee AuthenticationEmployee { get => _authenticationService.AuthenticationEmployee; }

        public ClientService(
            IAuthenticationService authenticationService,
            IEmployeesRepo userRepository,
            IClientsRepo clientRepository)
        {
            _authenticationService = authenticationService;
            _userRepository = userRepository;
            _clientRepository = clientRepository;
        }

        public IEnumerable<ClientDto> GetClients()
        {
            var clients = _clientRepository.GetClients();

            switch (_authenticationService.AuthenticationEmployee)
            {
                case Manager:
                    return clients.Select(c => new ClientDto()
                    {
                        ID = c.ID,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Patronymic = c.Patronymic,
                        PassportData = c.PassportData,
                        PhoneNumber = c.PhoneNumber,
                        Departament = c.Departament,
                        EditsDataLog = c.EditsDataLog
                    });

                case Consultant:
                    return clients.Select(c => new ClientDto()
                    {
                        ID = c.ID,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Patronymic = c.Patronymic,
                        PassportData = new(),
                        PhoneNumber = c.PhoneNumber,
                        Departament = c.Departament,
                        EditsDataLog = c.EditsDataLog
                    });

                default:
                    MessageBox.Show("Не выбран сотрудник");
                    Application.Current.Shutdown();
                    return null;
            }
        }
    }
}