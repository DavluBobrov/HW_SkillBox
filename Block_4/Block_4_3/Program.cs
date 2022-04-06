using System;


namespace Block_4_3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Игра \"Угадай-ка\"");
            Console.WriteLine("Введите до какого числа гадаем (начинается с нуля)");
            string data = Console.ReadLine();
            int n = Int32.Parse(data);
            Random rand = new Random();

            int iiNumber = rand.Next(1, n + 1);
            int count = 0;
            Console.Write("\nВведите число: ");
            count++;
            while (true)
            {
                data = Console.ReadLine();
                if (data != "")
                {
                    int userNumber = Int32.Parse(data);
                    if (userNumber < iiNumber)
                    {
                        Console.WriteLine("Введенное число меньше загаданного. Попробуйте ещё раз");
                    }
                    else if (userNumber > iiNumber)
                    {
                        Console.WriteLine("Введенное число больше загаданного. Попробуйте ещё раз");
                    }
                    else
                    {
                        Console.WriteLine($"Поздравляю, число угадано! Число попыток: {count}.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine($"Очень жаль, что вы сдались, загадано было число {iiNumber}");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
