using System;
using static System.Console;

namespace Block_4_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WriteLine("Введите длину последовательности");
            string data = ReadLine();
            int count = Int32.Parse(data);
            // Введено число, выводим что требуется
            int[] array = new int[count];
            WriteLine("Введите числа последовательности поочередно");

            for (int i = 0; i < count; i++)
            {
                data = ReadLine();
                int data_ar = Int32.Parse(data);
                array[i] = data_ar;
            }
            // Поиск максимума в последовательности
            int minValue = int.MaxValue;
            foreach (var n in array)
            {
                Write($"{n} ");
                if (n < minValue) minValue = n;
            }
            Write($"\nМинимальное значение последовательности minValue = {minValue}");
            ReadKey();
        }
    }
}