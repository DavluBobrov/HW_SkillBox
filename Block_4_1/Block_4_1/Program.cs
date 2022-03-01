using System;
using static System.Console;

namespace Block_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Запрос пользователю
            while (true)
            {
                WriteLine("Введите длину последовательности");
                string data = ReadLine();
                bool is_number = Int32.TryParse(data, out int count);           // Флаг проверки на введенные данные
                if (is_number)                                                  // Проверка на то, что введено именно число
                {
                    // Введено число, выводим что требуется
                    int[] array = new int[count];
                    WriteLine("Введите числа последовательности поочередно");
                    
                    for (int i = 0; i < count; i++)
                    {
                        data = ReadLine();
                        is_number = Int32.TryParse(data, out int data_ar);
                        if (is_number) array[i] = data_ar;
                        else
                        {
                            WriteLine("Данные введены неверно!");
                            i--;
                        }
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
                    break;                                                      // Принудительный выход из цикла
                }
                else
                {
                    // Ошибка ввода, давай по новой
                    Clear();
                    WriteLine("Данные введены неверно!");
                }
            }
        }
    }
}
