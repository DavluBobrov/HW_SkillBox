namespace Block_11_1
{
    internal class RealClient : Client
    {
        private int _iD;
        private string _lastName;
        private string _firstName;
        private string _patronymic;
        private string _phoneNumber;
        private Passport _passportData;

        public RealClient()
        {
        }

        public RealClient(int iD, string lastName, string firstName, string patronymic, string phoneNumber, Passport passportData = new Passport())
        {
            _iD = iD;
            _lastName = lastName;
            _firstName = firstName;
            _patronymic = patronymic;
            _phoneNumber = phoneNumber;
            _passportData = passportData;
        }

        public override string LastName { get => _lastName; set => _lastName = value; }
        public override string FirstName { get => _firstName; set => _firstName = value; }
        public override string Patronymic { get => _patronymic; set => _patronymic = value; }
        public override string PhoneNumber { get => _phoneNumber; set => _phoneNumber = EditTelephone(value); }
        public override Passport PassportData { get => _passportData; set => _passportData = value; }
        public override int ID { get => _iD; set => _iD = value; }
    }
}