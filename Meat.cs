public class Meat : FoodProduct
    {
        protected string _cut;
        protected string _type;

        public string Cut { get { return _cut;}}
        public string Type { get { return _type;}}

        public Meat(string name, double weight, DateTime expiryDate, string cut, string type) : base(name, weight, expiryDate)
        {
            _cut = cut;
            _type = type;
        }

        public override double GetQuality()
        {
            double quality = 10;
            if (Cut == "Poor") quality -= 2;
            else if (Cut == "Excellent") quality += 2;
            if (DateTime.Now.Date >= ExpiryDate.Date) quality -= 5;
            return quality;
        }

        public override string ToString()
        {
            return base.ToString() + $", Cut: {Cut}, Type: {Type}";
        }
    }
