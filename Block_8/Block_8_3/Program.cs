using System;
using System.Collections.Generic;


namespace Block_8_3
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> vs = new HashSet<int>();
            Console.WriteLine("Введите число для добавления в коллекцию");
            while (true)
            {
                int number = Int32.Parse(Console.ReadLine());
                if (vs.Contains(number))
                {
                    Console.WriteLine("Такое число уже есть в коллекции");
                }
                else
                {
                    vs.Add(number);
                    Console.WriteLine("Число успешно добавленно в коллекцию");
                }
            }
        }
    }
}
