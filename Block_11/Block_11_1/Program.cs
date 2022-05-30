using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Block_11_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Bank A = new();
            while (true)
            {
                Console.WriteLine("Кто работает в программе? 1 - Консультант, 2 - Менеджер");
                Consultant Employee = Console.ReadLine() switch
                {
                    "1" => new(A.GetClientsForConsiltant()),
                    "2" => new Manager(A.GetClientsForManager()),
                    _ => new Consultant(),
                };
                Console.Clear();
                do
                {
                    Menu();
                    if (Employee is Manager) Console.WriteLine("5 - Добавление нового клиента в БД");

                    switch (Console.ReadLine())
                    {
                        case "1": Employee.PrintAllClients(); break;
                        case "2":
                            Console.Write("Введите ID Клиента: ");
                            Employee.PrintClient(int.Parse(Console.ReadLine()));
                            break;

                        case "3":
                            Console.Write("Введите ID Клиента: ");
                            Employee.Edit(int.Parse(Console.ReadLine()));
                            break;

                        case "4": A.SerialazeDataClients(); break;
                        case "5":
                            if (Employee is Manager)
                            {
                                Console.WriteLine("Введите данные через пробел по порядку в виде:");
                                Console.WriteLine("Фамилия Имя Отчество Номертелефона(без +7 или 8) СерияПаспорта НомерПаспорта");
                                (Employee as Manager).AddNewClient(Console.ReadLine().Split(' '));
                            }
                            break;

                        default:
                            break;
                    }
                    Console.WriteLine("Продолжить исполнение программы? Д/Н");
                } while (Console.ReadLine().ToUpper() == "Д");

                //Employee.SerialazeDataClients();
                Console.ReadLine();
            }
        }

        private static void Menu()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Просмотр Всего списка клиентов");
            Console.WriteLine("2 - Просмотр отдельного криента по ID");
            Console.WriteLine("3 - Редактирование клиента по ID");
            Console.WriteLine("4 - Сохранение Изменений в файл");
        }
    }
}