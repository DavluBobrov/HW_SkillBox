using System;
using static System.Console;

namespace Block_4_1
{
    class Program
    {
        static void Main()
        {
            try
            {
                WriteLine("Введите количество строк");
                int row = Int32.Parse(ReadLine());
                WriteLine("Введите количество столбцов");
                int column = Int32.Parse(ReadLine());
                int[,] ar = new int[row, column];
                long sum = 0;
                Random r = new Random();
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        ar[i, j] = r.Next();
                        Write($"{ar[i, j]}\t");
                        sum += ar[i, j];
                    }
                    WriteLine();
                }
                WriteLine($"\nСумма элементов массива равна {sum}");
                ReadKey();
            }
            catch
            {
                Write("Ошибка Ввода");
                ReadKey();
            }
        }
    }
}
