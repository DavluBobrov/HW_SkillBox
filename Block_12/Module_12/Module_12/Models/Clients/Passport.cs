namespace Module_12.Models.Clients
{
    internal class Passport
    {
        private string _series;
        private string _number;

        public Passport(string series, string number)
        {
            _series = series;
            _number = number;
        }

        public Passport()
        {
            _number = string.Empty;
            _number = string.Empty;
        }

        public string Series
        {
            get => _series?.PadLeft(4, '*') ?? "****";
            set
            {
                _series = EditSeries(value);
            }
        }

        public string Number
        {
            get => _number?.PadLeft(6, '*') ?? "******";
            set
            {
                _number = EditNumber(value);
            }
        }

        public override string ToString()
        {
            return $"{Series?.PadLeft(4, '*')} {Number?.PadLeft(6, '*')}";
        }

        protected string EditSeries(string newSeries) => newSeries.Length == 4 ? $"{newSeries}" : this._series;

        protected string EditNumber(string newNumber) => newNumber.Length == 6 ? $"{newNumber}" : this._number;
    }
}