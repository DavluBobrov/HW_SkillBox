using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_11_1
{
    internal class Consultant
    {
        private List<Client> _Clients;

        public Consultant(List<Client> inputCollection)
        {
            _Clients = inputCollection;
        }

        public void PrintWorker(int ID)
        {
            Client w = GetClient(ID);
            if (w != null)
            {
                Console.WriteLine(w.ToString());
            }
            else Console.WriteLine("ID не найден.");
        }

        public void PrintAllClients()
        {
            foreach (var item in _Clients)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private Client GetClient(int ID)
        {
            foreach (var item in _Clients.Where(item => item.ID == ID))
            {
                return item;
            }
            return null;
        }
    }
}