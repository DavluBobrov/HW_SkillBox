using Module_12.Models.Clients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static Module_12.Models.EnumTypes;

namespace Module_12.Models.Employees
{
    internal class Consultant : IEditClient
    {
        private ObservableCollection<Departament> departaments;
        protected Client SelectedClient;

        public ObservableCollection<Departament> Departaments { get => departaments; set => departaments = value; }

        public Consultant()
        {
        }

        public Consultant(ObservableCollection<Departament> inputCollection)
        {
            Departaments = inputCollection;
        }

        public void PrintAllClients()
        {
            foreach (var item in Departaments)
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
            //foreach (var item in _Departaments.Where(item => item.ID == ID))
            //{
            //    SelectedClient = item;
            //    return item;
            //}
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

        public override string ToString()
        {
            return "Consultant";
        }
    }
}