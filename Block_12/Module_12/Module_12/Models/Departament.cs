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
        private ObservableCollection<Client> _Clients;

        public Departament(ObservableCollection<Client> clients)
        {
            _Clients = clients;
        }

        public ObservableCollection<Client> Clients { get => _Clients; set => _Clients = value; }

        public void AddCLient(Client newclient)
        {
            _Clients.Add(newclient);
            newclient.Departament = this;
        }
    }
}