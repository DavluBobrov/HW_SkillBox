using Module_12.Models.Clients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using static Module_12.Models.EnumTypes;

namespace Module_12.Models
{
    internal class Bank
    {
        private static ObservableCollection<Departament> _Departaments = new();
        private static int _MaxID;

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

        public List<Departament> GetClientsForConsiltant()
        {
            List<Departament> result = new();

            foreach (var item in _Departaments)
            {
                ObservableCollection<Client> consulClients = new();
                foreach (var cl in item.Clients)
                {
                    consulClients.Add(new ProxyConsulClient(cl as RealClient));
                }
                result.Add(new Departament(consulClients));
            }
            return result;
        }

        public List<Client> GetClientsForManager()
        {
            List<Client> result = new();
            result.AddRange(from item in _Clients
                            select new ProxyManagerClient(item));
            return result;
        }

        /// <summary>
        /// Добавление нового клиента в БД
        /// </summary>
        /// <param name="inputDataClient">
        /// Входные данные: [0] - LastName [1] - FirstName [2] - Patronymic [3] - PhoneNumber
        /// [4] - PassportData: series [5] - PassportData: number
        /// </param>
        public static Client AddNewClient(params string[] inputDataClient)
        {
            RealClient rCl = new()
            {
                LastName = inputDataClient[0],
                FirstName = inputDataClient[1],
                Patronymic = inputDataClient[2],
                PhoneNumber = inputDataClient[3],
                PassportData = new Passport
                {
                    Series = inputDataClient[4],
                    Number = inputDataClient[5]
                },
                ID = _MaxID + 1,
                EditsDataLog = InitLogs(TypeEmployee.Manager)
            };
            _Clients.Add(rCl);
            _MaxID++;
            return new ProxyManagerClient(rCl);
        }

        private static Dictionary<DataTypeClient, Log> InitLogs(TypeEmployee typeEmployee)
        {
            Dictionary<DataTypeClient, Log> EditsDataLog = new();
            EditsDataLog.Add(DataTypeClient.LastName, new Log(typeEmployee, TypeEdit.AddNew));
            EditsDataLog.Add(DataTypeClient.FirstName, new Log(typeEmployee, TypeEdit.AddNew));
            EditsDataLog.Add(DataTypeClient.Patronymic, new Log(typeEmployee, TypeEdit.AddNew));
            EditsDataLog.Add(DataTypeClient.PhoneNumber, new Log(typeEmployee, TypeEdit.AddNew));
            EditsDataLog.Add(DataTypeClient.PassportData, new Log(typeEmployee, TypeEdit.AddNew));
            EditsDataLog.Add(DataTypeClient.ID, new Log(typeEmployee, TypeEdit.AddNew));

            return EditsDataLog;
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
                    $"9{r.Next(100000000, 1000000000)}",
                    new Passport($"{r.Next(1000, 10000)}", $"{r.Next(100000, 1000000)}")
                    ));
                _Clients[i].EditsDataLog = InitLogs(TypeEmployee.Randomizer);
            }
        }

        private void DeserializeDataClients()
        {
            if (File.Exists("DataClients.json"))
                _Clients = JsonConvert.DeserializeObject<List<RealClient>>(File.ReadAllText("DataClients.json"));
            else
                FillClients();
        }

        public void SerialazeDataClients()
        {
            string jsonString = JsonConvert.SerializeObject(_Clients, Formatting.Indented); ;
            using (StreamWriter sw = new StreamWriter("DataClients.json"))
            {
                sw.WriteLine(jsonString);
            }
        }
    }
}