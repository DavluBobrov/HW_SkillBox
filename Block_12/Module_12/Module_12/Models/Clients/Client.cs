using System.Collections.Generic;
using static Module_12.Models.EnumTypes;

namespace Module_12.Models.Clients
{
    internal abstract class Client
    {
        public abstract string LastName { get; set; }
        public abstract string FirstName { get; set; }
        public abstract string Patronymic { get; set; }
        public abstract string PhoneNumber { get; set; }
        public abstract Passport PassportData { get; set; }

        //public Departament Departament { get; set; }
        public abstract int ID { get; set; }

        public override string ToString()
        {
            return $"{ID,4} {LastName,10} {FirstName,10} {Patronymic,15} {PhoneNumber,13} {PassportData,13}";
        }

        public Dictionary<DataTypeClient, Log> EditsDataLog { get; set; } = new();
    }
}