using System;
using static System.Console;

namespace Block_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Данные студента
            string FullName = "Пупкин Василий Ололоевич";
            int age = 37;
            string email = "VO_Pupkin@ya.ru";
            double points_code = 89.74;
            double points_math = 74.3;
            double points_pysh = 81.33;

            // Вывод даных
            WriteLine($"Имя студента: \t\t\t{FullName}");
            WriteLine($"Возраст: \t\t\t{age}");
            WriteLine($"email: \t\t\t\t{email}");
            WriteLine($"Баллы по Программированию: \t{points_code}");
            WriteLine($"Баллы по Математике: \t\t{points_math}");
            WriteLine($"Баллы по Физике: \t\t{points_pysh}");
            ReadKey();          // пауза
        }
    }
}
