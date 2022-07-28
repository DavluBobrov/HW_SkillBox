using Module_12.Models.Clients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static Module_12.Models.EnumTypes;

namespace Module_12.Models.Employees
{
    internal class Manager : Consultant
    {
        public Manager()
        {
            Departaments = Bank.ClientsForManager;
        }

        public override string ToString()
        {
            return "Manager";
        }
    }
}