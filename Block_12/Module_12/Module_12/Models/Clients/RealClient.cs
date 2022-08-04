using System;
using System.Collections.Generic;
using static Module_12.Models.EnumTypes;

namespace Module_12.Models.Clients
{
    internal class RealClient
    {
        private Guid _iD;
        private string _lastName;
        private string _firstName;
        private string _patronymic;
        private string _phoneNumber;
        private Passport _passportData;
        private string _departament;

        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string Patronymic { get => _patronymic; set => _patronymic = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = EditTelephone(value); }
        public Passport PassportData { get => _passportData; set => _passportData = value; }
        public Guid ID { get => _iD; set => _iD = value; }
        public string Departament { get => _departament; init => _departament = value; }
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
            _iD = new();
            _lastName = lastName;
            _firstName = firstName;
            _patronymic = patronymic;
            _phoneNumber = phoneNumber;
            _passportData = passportData;
            _departament = departament;
        }

        protected string EditTelephone(string newPhone) => newPhone.Length == 10 ? $"{newPhone}" : this.PhoneNumber;
    }
}