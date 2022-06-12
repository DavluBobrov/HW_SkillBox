using System;

namespace Module_12.Models.Clients
{
    internal class ProxyConsulClient : Client
    {
        private RealClient RClient;

        public ProxyConsulClient(RealClient rClient)
        {
            RClient = rClient;
        }

        public override string LastName { get => RClient.LastName; set => Console.WriteLine("Нет Доступа"); }
        public override string FirstName { get => RClient.FirstName; set => Console.WriteLine("Нет Доступа"); }
        public override string Patronymic { get => RClient.Patronymic; set => Console.WriteLine("Нет Доступа"); }
        public override string PhoneNumber { get => $"+7{RClient.PhoneNumber}"; set => RClient.PhoneNumber = value; }
        public override Passport PassportData { get => new Passport(); set => Console.WriteLine("Нет Доступа"); }
        public override int ID { get => RClient.ID; set => Console.WriteLine("Нет Доступа"); }
    }
}