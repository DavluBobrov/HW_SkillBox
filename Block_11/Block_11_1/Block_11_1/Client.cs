namespace Block_11_1
{
    internal class Client
    {
        private string _lastName;
        private string _firstName;
        private string _patronymic;
        private string _phoneNumber;
        private Passport _passportData;

        public Client()
        {
        }

        public Client(string lastName, string firstName, string patronymic, string phoneNumber, Passport passportData)
        {
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            PassportData = passportData;
        }

        public string LastName { get => _lastName; set => _lastName = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string Patronymic { get => _patronymic; set => _patronymic = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        internal Passport PassportData { get => _passportData; set => _passportData.ToString(); }
    }
}