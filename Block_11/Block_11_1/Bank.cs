using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_11_1
{
    internal class Bank
    {
        private static List<RealClient> _Clients = new();

        public Bank()
        {
            FillClients();
        }

        internal static List<RealClient> Clients { get => _Clients; set => _Clients = value; }

        public List<Client> GetClientsForConsiltant()
        {
            List<Client> result = new();
            result.AddRange(from item in Clients
                            select new ProxyConsulClient(item));
            return result;
        }

        private void FillClients()
        {
            Random r = new();
            int count = r.Next(0, 100);
            for (int i = 0; i < count; i++)
            {
                _Clients.Add(new RealClient(i,
                    $"lName{i}",
                    $"fName{i}",
                    $"Patronymic{i}",
                    $"+79{r.Next(10000000, 100000000)}",
                    new Passport($"{r.Next(1000, 10000)}", $"{r.Next(100000, 1000000)}")));
            }
        }
    }
}