using System;
using static System.Console;

namespace Block_5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Введите любой текст через пробел:"); 
            string input_text = ReadLine();
            ReverseWords(input_text);
            ReadKey();
        }

        /// <summary>
        /// Метод разбиения строки тества в массив
        /// </summary>
        /// <param name="text_to_split">Строка для ввода</param>
        /// <returns>Возвращает массив слов</returns>
        static string[] SplitTextInArray(string text_to_split)
        {
            return text_to_split.Split(' ');
        }

        /// <summary>
        /// Метод перестановки слов наоборот
        /// </summary>
        ///
        static void ReverseWords(string inputPhrase)
        {
            string[] arr = SplitTextInArray(inputPhrase);
            Array.Reverse(arr);
            PrintArrayWords(arr);
        }

        /// <summary>
        /// Метод печати массива слов на каждой строке
        /// </summary>
        /// <param name="arr">Входной массив слов</param>
        static void PrintArrayWords(string[] arr)
        {
            foreach (var arg in arr)
            {
                Write($"{arg} ");
            }
        }
    }
}
