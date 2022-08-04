using System;
using System.Collections.Generic;
using static Module_12.Models.EnumTypes;

namespace Module_12.Models.Clients
{
    internal class RealClient
    {
        private string _phoneNumber;

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = EditTelephone(value); }
        public Passport PassportData { get; set; }
        public Guid ID { get; set; }
        public string Departament { get; init; }
        public Dictionary<DataTypeClient, Log> EditsDataLog { get; set; } = new();

        public RealClient()
        {
        }

        public RealClient(string lastName,
                          string firstName,
                          string patronymic,
                          string phoneNumber,
                          Passport passportData,
                          string departament)
        {
            ID = new();
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            _phoneNumber = phoneNumber;
            PassportData = passportData;
            Departament = departament;
        }

        private string EditTelephone(string newPhone) => newPhone.Length == 10 ? $"{newPhone}" : this.PhoneNumber;
    }
}