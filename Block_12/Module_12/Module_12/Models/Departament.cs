using Module_12.Models.Clients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_12.Models
{
    internal class Departament
    {
        public Departament(string name)
        {
            Name = name;
            Clients = new();
        }

        public string Name { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
    }
}