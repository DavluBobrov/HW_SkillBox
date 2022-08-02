namespace Module_12.Models.Clients
{
    internal class RealClient
    {
        private int _iD;
        private string _lastName;
        private string _firstName;
        private string _patronymic;
        private string _phoneNumber;
        private Passport _passportData;

        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string Patronymic { get => _patronymic; set => _patronymic = value; }

        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = EditTelephone(value); }
        public Passport PassportData { get => _passportData; set => _passportData = value; }
        public int ID { get => _iD; set => _iD = value; }

        public RealClient()
        {
        }

        public RealClient(int iD, string lastName, string firstName, string patronymic, string phoneNumber, Passport passportData)
        {
            _iD = iD;
            _lastName = lastName;
            _firstName = firstName;
            _patronymic = patronymic;
            _phoneNumber = phoneNumber;
            _passportData = passportData;
        }

        protected string EditTelephone(string newPhone) => newPhone.Length == 10 ? $"{newPhone}" : this.PhoneNumber;
    }
}