using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Block_11_1.EnumTypes;

namespace Block_11_1
{
    internal class Consultant : IEditClient
    {
        protected List<Client> _Clients;
        protected Client SelectedClient;

        public Consultant()
        {
        }

        public Consultant(List<Client> inputCollection)
        {
            _Clients = inputCollection;
        }

        public void PrintAllClients()
        {
            foreach (var item in _Clients)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void PrintClient(int ID)
        {
            Client w = GetClient(ID);
            if (w != null)
            {
                Console.WriteLine(w.ToString());
            }
            else Console.WriteLine("ID не найден.");
        }

        protected Client GetClient(int ID)
        {
            foreach (var item in _Clients.Where(item => item.ID == ID))
            {
                SelectedClient = item;
                return item;
            }
            return null;
        }

        public void Edit(int clientID)
        {
            Edit(GetClient(clientID));
            Logging(DataTypeClient.PhoneNumber, TypeEmployee.Consultant);
        }

        public virtual void Edit(Client editClient)
        {
            Menu();
            EditPhoneNumber(Console.ReadLine());
        }

        protected virtual void EditPhoneNumber(string newPhone)
        {
            SelectedClient.PhoneNumber = newPhone;
        }

        protected virtual void Menu()
        {
            Console.WriteLine("Вы Можете менять только номер телефона:");
            Console.Write("Введите новый номер телефона без 8 или +7: ");
        }

        protected void Logging(DataTypeClient dataTypeClient, TypeEmployee typeEmployee)
        {
            if (SelectedClient.EditsDataLog.Keys.Contains(dataTypeClient))
                SelectedClient.EditsDataLog[dataTypeClient] = new Log(typeEmployee, TypeEdit.Edit);
            else
                SelectedClient.EditsDataLog.Add(dataTypeClient, new Log(typeEmployee, TypeEdit.AddNew));
        }
    }
}