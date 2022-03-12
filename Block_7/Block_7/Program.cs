using System;
using System.IO;

namespace Block_7
{
    class Program
    {
        static void Main()
        {
            do
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
                        Console.WriteLine("По возрастанию - 0, по убыванию - 1");
                        dir.SortCollection(Conv_0_1_toBool(Console.ReadLine()));
                        dir.Save();
                        break;
                    case "7":
                        dir.PrintCollection(); break;
                    default:
                        Console.WriteLine("Номер команды введен неверно!");
                        break;
                }
                Console.ReadKey();
                Console.WriteLine("Продолжить выполнение программы? y/n");
            } while (Console.ReadLine().ToUpper() == "Y");
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
            Console.WriteLine("7. Вывести справочник на экран:");
        }

        static bool Conv_0_1_toBool(string flag_str)
        {
            return flag_str == "1" ? true : false;
        }
    }
}
