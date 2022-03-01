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
                WriteLine("Введите количество строк");
                string data = ReadLine();
                bool is_number = Int32.TryParse(data, out int row);             // Флаг проверки на введенные данные
                if (is_number)                                                  // Проверка на то, что введено именно число
                {
                    while (true)
                    {
                        WriteLine("Введите количество столбцов");
                        data = ReadLine();
                        is_number = Int32.TryParse(data, out int column);           // Флаг проверки на введенные данные
                        if (is_number)                                              // Проверка на то, что введено именно число
                        {
                            int[,] ar = new int[row, column];
                            long sum = 0;
                            Random r = new Random();
                            for (int i = 0; i < row; i++)
                            {
                                for (int j = 0; j < column; j++)
                                {
                                    ar[i, j] = r.Next(-1000, 1001);
                                    Write($"{ar[i, j]}\t");
                                    sum += ar[i, j];
                                }
                                WriteLine();
                            }
                            WriteLine($"\nfСумма элементов массива равна {sum}");
                            break;
                        }
                        else
                        {
                            WriteLine("Данные введены неверно!");
                        }
                    }
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
