using Module_12.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using static Module_12.Models.EnumTypes;

namespace Module_12.Models.Employees
{
    internal class Manager : Consultant
    {
        public Manager(List<Client> inputCollection) : base(inputCollection)
        {
        }

        public void AddNewClient(string[] inputData)
        {
            _Clients.Add(Bank.AddNewClient(inputData));
        }

        public override void Edit(Client editClient)
        {
            Menu();
            var Items = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            foreach (var item in Items)
            {
                switch (item)
                {
                    case 1:
                        Console.Write("Новое Имя: ");
                        EditFirstName(Console.ReadLine());
                        break;

                    case 2:
                        Console.Write("Новая Фамилия: ");
                        EditLastName(Console.ReadLine());
                        break;

                    case 3:
                        Console.Write("Новое Отчество: ");
                        EditPatronymic(Console.ReadLine());
                        break;

                    case 4:
                        Console.Write("Новый номер телефона без 8 или +7: ");
                        EditPhoneNumber(Console.ReadLine());
                        break;

                    case 5:
                        Console.Write("Новык данные серии и номера паспорта через пробел: ");
                        EditPassportData(Console.ReadLine());
                        break;

                    default:
                        Console.WriteLine($"Нет такой команды: {item}");
                        break;
                }
            }
        }

        protected override void Menu()
        {
            Console.WriteLine("Напишите через пробел мункты, которые хотите поменять:");
            Console.WriteLine("1 - Имя");
            Console.WriteLine("2 - Фамилия");
            Console.WriteLine("3 - Отчество");
            Console.WriteLine("4 - Номер Телефона");
            Console.WriteLine("5 - Пасспортные данные");
        }

        private void EditPassportData(string v)
        {
            var strPassData = v.Split(' ');
            SelectedClient.PassportData = new Passport(strPassData[0], strPassData[1]);
            Logging(DataTypeClient.PassportData, TypeEmployee.Manager);
        }

        private void EditPatronymic(string v)
        {
            SelectedClient.Patronymic = v;
            Logging(DataTypeClient.Patronymic, TypeEmployee.Manager);
        }

        private void EditLastName(string v)
        {
            SelectedClient.LastName = v;
            Logging(DataTypeClient.LastName, TypeEmployee.Manager);
        }

        private void EditFirstName(string v)
        {
            SelectedClient.FirstName = v;
            Logging(DataTypeClient.FirstName, TypeEmployee.Manager);
        }
    }
}