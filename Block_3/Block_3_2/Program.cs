using System;
using static System.Console;

namespace Block_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Приветствую тебя, Игрок. \nСколько карт у тебя на руках?");
            while (true)
            {
                string number = ReadLine();
                bool is_number = Int32.TryParse(number, out int count);         // Флаг проверки на введенные данные
                int sum = 0;                                                    // Сумма очков
                if (is_number)                                                  // Проверка на то, что введено именно число
                {
                    // Введено число, выводим что требуется
                    WriteLine("Введите поочередно Ваши карты:");                                              
                    for (int i = 1; i <= count; i++)
                    {
                        WriteLine($"{i}-ая карта:");
                        string card = ReadLine().ToUpper();
                        switch (card)
                        {
                            case "A":
                            case "K":
                            case "Q":
                            case "J": sum += 10; break;
                            default:
                                is_number = Int32.TryParse(card, out int card_number);      // Флаг проверки на введенные данные
                                if (is_number && card_number > 1 && card_number < 11)       // Если введено число, то сразу проверяем диапазон чисел (возможных карт)  
                                {
                                    sum += card_number;
                                }
                                else
                                {
                                    // Ошибка ввода, давай по новой
                                    WriteLine("Ошибка при вводе карты, введите ее снова.");
                                    i--;
                                }
                                break;
                        }
                    }
                    WriteLine($"\nСумма набранных вами очков равна: {sum}");                // Вывод суммы очков
                    break;      // Принудительный выход из цикла
                }
                else
                {
                    // Ошибка ввода, давай по новой
                    Clear();
                    WriteLine("Данные введены неверно! Укажите количество карт цифрами");
                }
            }

        }
    }
}
