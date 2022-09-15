using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_13
{
    public class Client
    {
        public static int MaxID = 0;

        public Client()
        {
            ID = ++MaxID;
        }

        public int ID { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public Deposite<Funtic> Deposit { get; init; }
        public NotDeposit<Funtic> NotDeposit { get; init; }
    }

    public class Bank
    {
        public List<Client> Clients { get; set; }

        public Bank()
        {
            Clients = new();
            FillClients();
        }

        private void FillClients()
        {
            Random r = new();
            int count = r.Next(0, 100);
            for (int i = 0; i < count; i++)
            {
                Clients.Add(new Client()
                {
                    Deposit = new Deposite<Funtic>(),
                    NotDeposit = new NotDeposit<Funtic>(),
                    FirstName = $"Name{i}",
                    LastName = $"Last{i}"
                });
            }
        }
    }
}