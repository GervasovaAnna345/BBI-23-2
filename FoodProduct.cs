using System.Xml.Serialization;

    public class FoodProduct
    {
        
        protected string _name;
       
        protected double _weight;
       
        protected DateTime _expiryDate;

        public string Name { get { return _name; } }
        public double Weight { get { return _weight; }}
        public DateTime ExpiryDate { get { return _expiryDate; }}

        public FoodProduct(string name, double weight, DateTime expiryDate)
        {
            _name = name;
            _weight = weight;
            _expiryDate = expiryDate;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Weight: {Weight}kg, Expiry Date: {ExpiryDate.ToString("dd.MM.yyyy")}";
        }

        public virtual double GetQuality() { return 10; }
        public static bool operator ==(FoodProduct a, FoodProduct b)
        {
            if (a._name == b._name && a._weight == b._weight && a._expiryDate == b._expiryDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(FoodProduct a, FoodProduct b)
        {
            return !(a == b);
        }
        public static bool operator >(FoodProduct a, FoodProduct b)
        {
            return (a._name.CompareTo(b._name) == 1);
        }
        public static bool operator <(FoodProduct a, FoodProduct b)
        {
            return (a._name.CompareTo(b._name) == -1);
        }
}