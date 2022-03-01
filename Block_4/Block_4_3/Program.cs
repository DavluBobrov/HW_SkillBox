using System;


namespace Block_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Игра \"Угадай-ка\"");
            while (true)
            {
                Console.WriteLine("Введите до какого числа гадаем (начинается с нуля)");
                string data = Console.ReadLine();
                bool is_number = Int32.TryParse(data, out int n);
                if (is_number)
                {
                    Random rand = new Random();

                    int iiNumber = rand.Next(1, n + 1);
                    int count = 0;

                    while (true)
                    {
                        Console.Write("\nВведите число: ");
                        count++;
                        data = Console.ReadLine();
                        if (data != " ")
                        {
                            is_number = Int32.TryParse(data, out int userNumber);
                            if (is_number)
                            {
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
                                    Console.ReadKey();
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ошибка Ввода! Если хотите прекратить игру, нажмите пробел.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Очень жаль, что вы сдались, загадано было число {iiNumber}");
                            Console.ReadKey();
                            break;
                        }
                    }
                    break;
                }
                else Console.WriteLine("Ошибка ввода");
            }
        }
    }
}
