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
        private static Dictionary<string, Departament> _DepartamentMap = new();

        private static int _MaxID;

        public static Dictionary<string, Departament> DepartamentMap { get => _DepartamentMap; set => _DepartamentMap = value; }
        public static ObservableCollection<Departament> ClientsForConsiltant { get => GetClientsForConsiltant(); }
        public static ObservableCollection<Departament> ClientsForManager { get => GetClientsForManager(); }
        public static int MaxID { get => _MaxID; set => _MaxID = value; }

        public Bank()
        {
            DeserializeDataClients();
            CalculateMaxID();
        }

        private void CalculateMaxID()
        {
            foreach (var dep in DepartamentMap.Values)
            {
                foreach (var cl in dep.Clients)
                {
                    if (MaxID < cl.ID) MaxID = cl.ID;
                }
            }
        }

        private static ObservableCollection<Departament> GetClientsForConsiltant()
        {
            ObservableCollection<Departament> result = new();

            foreach (var item in DepartamentMap.Values)
            {
                Departament ToAddDep = new(item.Name);
                ObservableCollection<Client> clCollToAdd = new();
                foreach (var cl in item.Clients)
                {
                    clCollToAdd.Add(new ProxyConsulClient((RealClient)cl));
                }
                ToAddDep.Clients = clCollToAdd;
                result.Add(ToAddDep);
            }
            return result;
        }

        private static ObservableCollection<Departament> GetClientsForManager()
        {
            ObservableCollection<Departament> result = new();

            foreach (var item in DepartamentMap.Values)
            {
                Departament ToAddDep = new(item.Name);
                ObservableCollection<Client> clCollToAdd = new();
                foreach (var cl in item.Clients)
                {
                    clCollToAdd.Add(new ProxyManagerClient((RealClient)cl));
                }
                ToAddDep.Clients = clCollToAdd;
                result.Add(ToAddDep);
            }
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
            int count = r.Next(0, 250);
            for (int i = 0; i < count; i++)
            {
                string newName = $"dep_{r.Next(1, 10)}";
                if (!DepartamentMap.ContainsKey(newName))
                    DepartamentMap.Add(newName, new Departament(newName));
                RealClient toAddClient = new(
                    i,
                    $"lName{i}",
                    $"fName{i}",
                    $"Patronymic{i}",
                    $"9{r.Next(100000000, 1000000000)}",
                    new Passport($"{r.Next(1000, 10000)}", $"{r.Next(100000, 1000000)}"))
                {
                    EditsDataLog = InitLogs(TypeEmployee.Randomizer),
                };

                DepartamentMap[newName].Clients.Add(toAddClient);
            }
        }

        private void DeserializeDataClients()
        {
            if (File.Exists("DataClients.json"))
                DepartamentMap = JsonConvert.DeserializeObject<Dictionary<string, Departament>>(File.ReadAllText("DataClients.json"));
            else
                FillClients();
        }

        public void SerialazeDataClients()
        {
            string jsonString = JsonConvert.SerializeObject(DepartamentMap, Formatting.Indented); ;
            using (StreamWriter sw = new StreamWriter("DataClients.json"))
            {
                sw.WriteLine(jsonString);
            }
        }
    }
}