using System;

namespace Block_11_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Bank A = new();
            Consultant Consul = new(A.GetClientsForConsiltant());
            Consul.PrintAllClients();
            Console.ReadLine();
        }
    }
}