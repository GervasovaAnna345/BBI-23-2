 public class Fruit : FoodProduct
    {
        private string _ripeness;
        private string _variety;

        public string Ripeness { get { return _ripeness; } }
        public string Variety { get { return _variety; } }

        public Fruit(string name, double weight, DateTime expiryDate, string ripeness, string variety) : base(name, weight, expiryDate)
        {
            _ripeness = ripeness;
            _variety = variety;
        }

        public override double GetQuality()
        {
            double quality = 10;
            if (Ripeness == "Underripe") quality -= 2;
            else if (Ripeness == "Overripe") quality -= 3;
            if (DateTime.Now.Date >= ExpiryDate.Date) quality -= 5;
            return quality;
        }

        public override string ToString()
        {
            return base.ToString() + $", Ripeness: {Ripeness}, Variety: {Variety}";
        }
    }