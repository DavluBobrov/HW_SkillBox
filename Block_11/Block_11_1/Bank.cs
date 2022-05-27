using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Block_11_1
{
    internal class Bank
    {
        private static List<RealClient> _Clients = new();
        private int _MaxID;

        public Bank()
        {
            DeserializeDataClients();
            MaxID();
        }

        private void MaxID()
        {
            foreach (var item in _Clients)
            {
                if (_MaxID < item.ID) _MaxID = item.ID;
            }
        }

        public List<Client> GetClientsForConsiltant()
        {
            List<Client> result = new();
            result.AddRange(from item in _Clients
                            select new ProxyConsulClient(item));
            return result;
        }

        public List<Client> GetClientsForManager()
        {
            List<Client> result = new();
            result.AddRange(from item in _Clients
                            select new ProxyManagerClient(item));
            return result;
        }

        public static void AddNewClient(params string[] inpurDataClient)
        {
            _Clients.Add();
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
                    $"+79{r.Next(100000000, 1000000000)}",
                    new Passport($"{r.Next(1000, 10000)}", $"{r.Next(100000, 1000000)}")));
            }
        }

        private void DeserializeDataClients()
        {
            if (File.Exists("DataClients.json"))
                _Clients = JsonSerializer.Deserialize(File.ReadAllText("DataClients.json"), typeof(List<RealClient>)) as List<RealClient>;
            else
                FillClients();
        }

        public void SerialazeDataClients()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(_Clients, options: options);
            using (StreamWriter sw = new StreamWriter("DataClients.json"))
            {
                sw.WriteLine(jsonString);
            }
        }
    }
}