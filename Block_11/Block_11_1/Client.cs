using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_11_1
{
    abstract class Client
    {
        public abstract string LastName { get; set; }
        public abstract string FirstName { get; set; }
        public abstract string Patronymic { get; set; }
        public abstract string PhoneNumber { get; set; }
        public abstract Passport PassportData { get; set; }
        public abstract int ID { get; }

        public override string ToString()
        {
            return $"{ID,4} {LastName,10} {FirstName,10} {Patronymic,15} {PhoneNumber,13} {PassportData,13}";
        }
    }
}