using System;
using System.IO;

namespace Block_7
{
    class Program
    {
        static void Main()
        {
            string dirPath = "Directory.txt";
            CollectionDir dir = new(dirPath);
            Menu();
            
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Введите ID");
                    int id = Int32.Parse(Console.ReadLine());
                    CollectionDir.PrintTitle();
                    dir.PrintWorker(id);
                    break;
                case "2": 
                    dir.AddMember(dirPath); break;
                case "3":
                    Console.Write("Введите ID сотрудника, которого хотите удалить: ");
                    dir.RemoveMember(Int32.Parse(Console.ReadLine()));
                    break;
                case "4":
                    Console.Write("Введите ID сотрудника, которого хотите изменить: ");
                    dir.EditingMember(Int32.Parse(Console.ReadLine()));
                    dir.Save();
                    break;
                case "5":
                    Console.WriteLine("Введите диапазон дат в формате 01.01.2000 начиная с меньшей");
                    dir.PrintDateRange(DateTime.Parse(Console.ReadLine()), DateTime.Parse(Console.ReadLine()));
                    break;
                case "6":
                    dir.SortCollection();
                    dir.Save();
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }

        static void Menu()
        {
            Console.WriteLine("Введите команду (1-6):");
            Console.WriteLine("1. Просмотр записи по ID:");
            Console.WriteLine("2. Добавление нового сотрудника:");
            Console.WriteLine("3. Удаление записи по ID:");
            Console.WriteLine("4. Редактирование записи:");
            Console.WriteLine("5. Загрузка записий по выбранному диапазону дат:");
            Console.WriteLine("6. Сортировка списка по датам:");
        }
    }
}
