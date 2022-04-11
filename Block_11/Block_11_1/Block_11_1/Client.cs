using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_11_1
{
    class Client
    {
        string _lastName;
        string _firstName;
        string _patronymic;
        string _phoneNumber;
        Passport _passportData;
        PhoneCall phoneCall;

        public Client()
        {
        }

        public Client(string lastName, string firstName, string patronymic, string phoneNumber, Passport passportData)
        {
            _lastName = lastName;
            _firstName = firstName;
            _patronymic = patronymic;
            _phoneNumber = phoneNumber;
            _passportData = passportData;
        }
    }
}
