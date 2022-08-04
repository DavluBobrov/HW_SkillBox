using Module_12.Models.Clients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using static Module_12.Models.EnumTypes;

namespace Module_12.Models.Repositories
{
    internal class ClientsRepo : IClientsRepo
    {
        public ClientsRepo()
        {
            DeserializeDataClients();
        }

        private List<RealClient> _clients { get; set; }

        public IEnumerable<RealClient> GetClients() => _clients;

        private void DeserializeDataClients()
        {
            if (File.Exists("DataClients.json"))
                _clients = JsonConvert.DeserializeObject<List<RealClient>>(File.ReadAllText("DataClients.json"));
            else
                FillClients();
        }

        private void FillClients()
        {
            _clients = new();
            Random r = new();
            int count = r.Next(0, 30);
            for (int i = 0; i < count; i++)
            {
                string departamentName = $"dep_{r.Next(1, 5)}";
                RealClient toAddClient = new(
                    $"lName{i}",
                    $"fName{i}",
                    $"Patronymic{i}",
                    $"9{r.Next(100000000, 1000000000)}",
                    new Passport($"{r.Next(1000, 10000)}", $"{r.Next(100000, 1000000)}"),
                    departamentName
                    )
                {
                    EditsDataLog = InitLogs(TypeEmployee.Randomizer),
                };
                _clients.Add(toAddClient);
            }
        }

        private Dictionary<DataTypeClient, Log> InitLogs(TypeEmployee randomizer)
        {
            Dictionary<DataTypeClient, Log> EditsDataLog = new();
            EditsDataLog.Add(DataTypeClient.LastName, new Log(randomizer, TypeEdit.AddNew));
            EditsDataLog.Add(DataTypeClient.FirstName, new Log(randomizer, TypeEdit.AddNew));
            EditsDataLog.Add(DataTypeClient.Patronymic, new Log(randomizer, TypeEdit.AddNew));
            EditsDataLog.Add(DataTypeClient.PhoneNumber, new Log(randomizer, TypeEdit.AddNew));
            EditsDataLog.Add(DataTypeClient.PassportData, new Log(randomizer, TypeEdit.AddNew));
            EditsDataLog.Add(DataTypeClient.ID, new Log(randomizer, TypeEdit.AddNew));

            return EditsDataLog;
        }
    }
}