public class Backery : FoodProduct
    {
        private string _freshness;
        private string _type;

        public string Freshness { get { return _freshness; } }
        public string Type { get { return _type; } }

        public Backery(string name, double weight, DateTime expiryDate, string freshness, string type) : base(name, weight, expiryDate)
        {
            _freshness = freshness;
            _type = type;
        }

        public override double GetQuality()
        {
            double quality = 8;
            if (Freshness == "Stale") quality -= 3;
            else if (Freshness == "Fresh") quality += 2;
            if (DateTime.Now.Date >= ExpiryDate.Date) quality -= 5;
            return quality;
        }

        public override string ToString()
        {
            return base.ToString() + $", Freshness: {Freshness}, Type: {Type}";
        }
    }