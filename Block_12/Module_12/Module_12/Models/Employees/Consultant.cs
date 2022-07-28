using Module_12.Models.Clients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static Module_12.Models.EnumTypes;

namespace Module_12.Models.Employees
{
    internal class Consultant
    {
        private ObservableCollection<Departament> departaments;

        public ObservableCollection<Departament> Departaments { get => departaments; set => departaments = value; }

        public Consultant()
        {
            departaments = Bank.ClientsForConsiltant;
        }

        //public Consultant(ObservableCollection<Departament> inputCollection)
        //{
        //    Departaments = inputCollection;
        //}

        public override string ToString()
        {
            return "Consultant";
        }
    }
}