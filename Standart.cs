public struct Standart
{
    private string _name;
    public string Name { get { return _name; } }
    private double[] _values;
    public Standart(string name, double[] values)
    {
        _name = name;
        _values = values;
    }
    public double Value(int index)
    {
        return _values[index];
    }
}