namespace Block_11_1
{
    internal struct Passport
    {
        private string _series;
        private string _number;

        public Passport(string series, string number) : this()
        {
            Series = series;
            Number = number;
        }

        public string Series { get => _series; set => _series = value; }
        public string Number { get => _number; set => _number = value; }

        public override string ToString()
        {
            return $"{Series} {Number}";
        }
    }
}