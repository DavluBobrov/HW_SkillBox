using System;
using System.Collections.Generic;

namespace Block_8_1
{
    class Program
    {
        static void Main()
        {
            List<int> Numbers = new List<int>();
            FillList(ref Numbers);
            PrintList(Numbers);
            Console.ReadKey();
            Console.WriteLine();
            RemoveElements(ref Numbers);
            PrintList(Numbers);
            Console.ReadKey();
        }

        static void FillList(ref List<int> list)
        {
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                list.Add(r.Next(101));
            }
        }

        static void PrintList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i],4} ");
                if ((i + 1) % 10 == 0) Console.WriteLine();
            }
        }

        static void RemoveElements(ref List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] >= 25 && list[i] <= 50)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
