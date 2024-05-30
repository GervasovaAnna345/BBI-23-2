public class FriedMeat : Meat
{
    private Standart _standart;
    private bool _hasStandart = false;
    public FriedMeat(string name, double weight, DateTime expiryDate, string cut, string type) : base(name, weight, expiryDate, cut, type)
    {
    }

    public FriedMeat(string name, double weight, DateTime expiryDate, string cut, string type, Standart standart) : base(name, weight, expiryDate, cut, type)
    {
        _standart = standart;
        _hasStandart = true;
    }
    public override double GetQuality()
    {
        if (_hasStandart)
        {
            int res = 0;
            int days;
            DateTime now = DateTime.Today;
            string dif = _expiryDate.Subtract(now).ToString();
            if (!dif.Contains("."))
            {
                days = 0;
            }
            else
            {
                days = int.Parse(dif.Split('.')[0]);
            }
            for (int i = 0; i < 10; i++)
            {
                if (days > _standart.Value(i)) { res = i + 1; }
            }
            return res;
        }
        return base.GetQuality();
    }
}
