using System;
using System.Collections.Generic;

namespace Block_8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> PhoneBook = new Dictionary<string, string>();
            FillDictionary(ref PhoneBook);
            Console.ReadKey();
            UserSearch(PhoneBook);
            Console.ReadKey();
        }

        static void FillDictionary(ref Dictionary<string,string> phonebook)
        {
            do
            {
                Console.Write("Введите номер телефона: ");
                string number = Console.ReadLine();
                if (number == string.Empty) break;
                Console.Write("Введите ФИО: ");
                string FullName = Console.ReadLine();
                if (FullName == string.Empty) break;
                phonebook.Add(number, FullName);
            } while (true);
        }

        static void UserSearch(Dictionary<string, string> phonebook)
        {
            while (true)
            {
                Console.Write("\nВведите номер телефона для поиска: ");
                string data = Console.ReadLine();
                if (phonebook.ContainsKey(data))
                {
                    Console.WriteLine($"\nФИО Владельца: {phonebook[data]}");
                    break;
                }
                else
                    Console.WriteLine("Такого номера нет в справочнике");
            }
        }
    }
}
