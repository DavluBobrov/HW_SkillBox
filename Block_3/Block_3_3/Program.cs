using System;
using static System.Console;

namespace Block_3_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Запрос пользователю
            while (true)
            {
                WriteLine("Введите число");
                string data = ReadLine();
                bool is_number = Int32.TryParse(data, out int number);          // Флаг проверки на введенные данные
                if (is_number)                                                  // Проверка на то, что введено именно число
                {
                    // Введено число, проверяем число на все делители
                    int i = 2;
                    bool isSimple = true;
                    while (i < number)
                    {
                        if (number % i == 0)
                        {
                            isSimple = false;
                            break;              // Принудительный выход из цикла
                        }
                        i++;
                    }

                    if (isSimple) WriteLine("Введенное число является простым");
                    else WriteLine("Введенное число НЕ является простым");

                    break;                      // Принудительный выход из цикла
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