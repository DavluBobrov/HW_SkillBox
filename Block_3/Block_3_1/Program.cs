using System;
using static System.Console;

namespace Block_3_1
{
    class Program
    {
        static void Main()
        {
            // Запрос пользователю
            while (true)
            {
                WriteLine("Введите число");
                string data = ReadLine();                
                bool is_number = Int32.TryParse(data, out int number);          // Флаг проверки на введенные данные
                if (is_number)                                                  // Проверка на то, что введено именно число
                {
                    // Введено число, выводим что требуется
                    if (number % 2 == 0) WriteLine("Введённое число является Чётным.");
                    else WriteLine("Введённое число является Нечётным.");
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
