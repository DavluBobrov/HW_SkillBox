using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_11_1
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
        public override string PhoneNumber { get => RClient.PhoneNumber; set => EditTelephone(value); }
        public override Passport PassportData { get => new Passport(); set => Console.WriteLine("Нет Доступа"); }
        public override int ID { get => RClient.ID; }

        private string EditTelephone(string newPhone) => newPhone.Length == 10 ? $"+7{newPhone}" : RClient.PhoneNumber;
    }
}