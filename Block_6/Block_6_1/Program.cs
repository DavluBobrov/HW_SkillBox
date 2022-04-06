using System;
using System.IO;
using static System.Console;

namespace Block_6_1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Вывод справочника на экран:");
            Console.WriteLine("2. Ввод нового сотрудника:");
            string pathDir = "Dyrectory.txt";
            switch (ReadLine())
            {
                case "1": PrintDyrectory(pathDir); break;
                case "2": AddMember(pathDir); break;

                default:
                    Write("Ошибка ввода");
                    break;
            }
        }

        /// <summary>
        /// Вывод справочника на экран
        /// </summary>
        /// <param name="path">Путь до Справочника</param>
        static void PrintDyrectory(string dirPath)
        {
            if (File.Exists(dirPath))
            {
                string[] allText = File.ReadAllLines(dirPath);
                WriteLine($"{"ID",2}{"Дата записи",20}{"Полное Имя",30}" +
                        $"{"Возраст",8}{"Рост",5}{"Дата рождения",15}{"Место рождения",15}\n");
                foreach (var str in allText)
                {
                    string[] splitText = str.Split("#");
                    WriteLine($"{splitText[0],2}{splitText[1],20}{splitText[2],30}" +
                        $"{splitText[3],8}{splitText[4],5}{splitText[5],15}{splitText[6],15}");
                }
            }
            else
            {
                Write("Файл не найден, создан пустой файл");
                File.Create(dirPath);
            }
        }

        /// <summary>
        /// Метод добавления нового сотрудника
        /// </summary>
        /// <param name="dirPath">Путь до Справочника</param>
        static void AddMember(string dirPath)
        {
            //1#20.12.2021 00:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва
            int ID;
            if (!File.Exists(dirPath))
            {
                ID = 0;
            }
            else
            {
                string[] allText = File.ReadAllLines(dirPath);
                ID = allText.Length + 1;
            }
            
            string FullName = "";
            #region Data Input
            Console.Write("Введите Имя: ");
            FullName += $"{ReadLine()} ";
            Console.Write("Введите Фамилию: ");
            FullName += $"{ReadLine()} ";
            Console.Write("Введите Отчество: ");
            FullName += ReadLine();
            Console.Write("Введите Рост: ");
            double height = Double.Parse(ReadLine());
            Console.Write("Введите Дату рождения через точку (01.01.2000): ");
            DateTime DateОfBirth = DateTime.Parse(ReadLine());
            Console.Write("Введите Место рождения: ");
            string birthPlace = ReadLine();
            #endregion
            DateTime dateAdd = DateTime.Now;
            int age = (dateAdd - DateОfBirth).Days / 365;        // Вычисление возраста
            string addText = $"{ID}#{dateAdd.ToShortDateString()} {dateAdd.ToShortTimeString()}" +
                             $"#{FullName}#{age}#{height}#{DateОfBirth.ToShortDateString()}#{birthPlace}\n";
            File.AppendAllText(dirPath, addText);
        }

    }
}
