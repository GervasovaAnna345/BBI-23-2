 public class Vegetable : FoodProduct
    {
        private string _freshness;
        private string _type;

        public string Freshness { get { return _freshness; } }   
        public string Type { get { return _type; } }

        public Vegetable(string name, double weight, DateTime expiryDate, string freshness, string type) : base(name, weight, expiryDate)
        {
            _freshness = freshness;
            _type = type;
        }

        public override double GetQuality()
        {
            double quality = 10;
            if (Freshness == "Bad") quality -= 3;
            else if (Freshness == "Good") quality += 2;
            if (DateTime.Now.Date >= ExpiryDate.Date) quality -= 5;
            return quality;
        }

        public override string ToString()
        {
            return base.ToString() + $", Freshness: {Freshness}, Type: {Type}";
        }
    }