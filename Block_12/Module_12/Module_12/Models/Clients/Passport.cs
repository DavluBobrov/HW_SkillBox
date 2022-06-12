namespace Module_12.Models.Clients
{
    internal struct Passport
    {
        private string _series;
        private string _number;

        public Passport(string series, string number)
        {
            _series = series;
            _number = number;
        }

        public string Series { get => _series?.PadLeft(4, '*') ?? "****"; set => _series = value; }
        public string Number { get => _number?.PadLeft(6, '*') ?? "******"; set => _number = value; }

        public override string ToString()
        {
            return $"{Series?.PadLeft(4, '*')} {Number?.PadLeft(6, '*')}";
        }
    }
}