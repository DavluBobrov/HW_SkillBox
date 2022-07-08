using Module_12.Models.Clients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using static Module_12.Models.EnumTypes;

namespace Module_12.Models.Employees
{
    internal class Bank
    {
        public static ObservableCollection<Departament> _Departaments = new();
        private Dictionary<string, Departament> _DepartamentMap = new();
        private static int _MaxID;

        public Bank()
        {
            DeserializeDataClients();
            MaxID();
        }

        private void MaxID()
        {
            foreach (var dep in _Departaments)
            {
                foreach (var cl in dep.Clients)
                {
                    if (_MaxID < cl.ID) _MaxID = cl.ID;
                }
            }
        }

        public ObservableCollection<Client> GetClientsForConsiltant()
        {
            //ObservableCollection<Departament> result = new();
            //result.AddRange(from item in _Departaments
            //                select new Departament(item));
            //return result;
            return null;
        }

        public List<Client> GetClientsForManager()
        {
            //List<Client> result = new();
            //result.AddRange(from item in _Departaments
            //                select new ProxyManagerClient(item));
            //return result;
            return null;
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
            //RealClient rCl = new()
            //{
            //    LastName = inputDataClient[0],
            //    FirstName = inputDataClient[1],
            //    Patronymic = inputDataClient[2],
            //    PhoneNumber = inputDataClient[3],
            //    PassportData = new Passport
            //    {
            //        Series = inputDataClient[4],
            //        Number = inputDataClient[5]
            //    },
            //    ID = _MaxID + 1,
            //    EditsDataLog = InitLogs(TypeEmployee.Manager)
            //};
            //_Departaments.Add(rCl);
            //_MaxID++;
            //return new ProxyManagerClient(rCl);
            return null;
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
                string newName = $"dep_{r.Next(1, 10)}";
                if (!_DepartamentMap.ContainsKey(newName))
                    _DepartamentMap.Add(newName, new Departament(newName));
                RealClient toAddClient = new(
                    i,
                    $"lName{i}",
                    $"fName{i}",
                    $"Patronymic{i}",
                    $"9{r.Next(100000000, 1000000000)}",
                    new Passport($"{r.Next(1000, 10000)}", $"{r.Next(100000, 1000000)}"))
                {
                    EditsDataLog = InitLogs(TypeEmployee.Randomizer)
                };

                _DepartamentMap[newName].Clients.Add(toAddClient);
            }
        }

        private void DeserializeDataClients()
        {
            if (File.Exists("DataClients.json"))
                _Departaments = JsonConvert.DeserializeObject<ObservableCollection<Departament>>(File.ReadAllText("DataClients.json"));
            else
                FillClients();
        }

        public void SerialazeDataClients()
        {
            string jsonString = JsonConvert.SerializeObject(_Departaments, Formatting.Indented); ;
            using (StreamWriter sw = new StreamWriter("DataClients.json"))
            {
                sw.WriteLine(jsonString);
            }
        }
    }
}