using static System.Console;

namespace Block_5_1
{
    internal class Program
    {
        private static void Main()
        {
            WriteLine("Введите любой текст через пробел:");
            //PrintArrayWords(SplitTextInArray(ReadLine()));
            string data = ReadLine();
            string[] split_data = SplitTextInArray(data);
            PrintArrayWords(split_data);
            ReadKey();
        }

        /// <summary>
        /// Метод разбиения строки тества в массив
        /// </summary>
        /// <param name="text_to_split">Строка для ввода</param>
        /// <returns></returns>
        private static string[] SplitTextInArray(string text_to_split)
        {
            return text_to_split.Split(' ');
        }

        /// <summary>
        /// Метод печати массива слов на каждой строке
        /// </summary>
        /// <param name="arr">Входной массив слов</param>
        private static void PrintArrayWords(string[] arr)
        {
            foreach (var arg in arr)
            {
                WriteLine(arg);
            }
        }
    }
}