using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_11_1
{
    internal class ProxyManagerClient : Client
    {
        private RealClient RClient = new();

        public ProxyManagerClient(RealClient rClient)
        {
            RClient = rClient;
        }

        public override string LastName { get => RClient.LastName; set => RClient.LastName = value; }
        public override string FirstName { get => RClient.FirstName; set => RClient.FirstName = value; }
        public override string Patronymic { get => RClient.Patronymic; set => RClient.Patronymic = value; }
        public override string PhoneNumber { get => RClient.PhoneNumber; set => RClient.PhoneNumber = value; }
        public override Passport PassportData { get => RClient.PassportData; set => RClient.PassportData = value; }
        public override int ID { get => RClient.ID; set => Console.WriteLine("Нет Доступа"); }
    }
}