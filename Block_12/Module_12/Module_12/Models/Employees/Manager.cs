using Module_12.Models.Clients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static Module_12.Models.EnumTypes;

namespace Module_12.Models.Employees
{
    internal class Manager : IEmployee
    {
        public bool IsManager { get; set; }

        public Manager()
        {
            IsManager = true;
        }

        public override string ToString()
        {
            return "Manager";
        }
    }
}