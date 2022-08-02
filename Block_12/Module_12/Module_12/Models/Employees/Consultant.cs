using Module_12.Models.Clients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static Module_12.Models.EnumTypes;

namespace Module_12.Models.Employees
{
    internal class Consultant : IEmployee
    {
        public bool IsManager { get; set; }

        public Consultant()
        {
            IsManager = false;
        }

        public override string ToString()
        {
            return "Consultant";
        }
    }
}