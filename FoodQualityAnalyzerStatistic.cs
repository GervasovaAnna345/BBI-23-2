public partial class FoodQualityAnalyzer : IStatistic {
    public double AverrageQuality()
    {
        double sum = 0;
        foreach(FoodProduct product in _products){
            
            sum += product.GetQuality();
            
        }
        return sum / _products.Length;
    }

    public double MaxQuality()
    {
        double maxQuality = 0;
        foreach(FoodProduct product in _products){
            if(maxQuality < product.GetQuality()){
                maxQuality = product.GetQuality();
            }
        }
        return maxQuality;
    }

    public double MinQuality()
    {
        double minQuality = _products[0].GetQuality();
        foreach(FoodProduct product in _products){
            if(minQuality > product.GetQuality()){
                minQuality = product.GetQuality();
            }
        }
        return minQuality;
    }

    public double MedianQuality()
    {
        FoodProduct[] _sorted = _products.ToArray();
        FoodProduct temp;
        for (int i = 0; i < _sorted.Length; i++)
        {
            for (int j = i + 1; j < _sorted.Length; j++)
            {
                if (_sorted[i].GetQuality() > _sorted[j].GetQuality())
                {
                    temp = _sorted[i];
                    _sorted[i] = _sorted[j];
                    _sorted[j] = temp;
                }
            }
        }
        if (_sorted.Length % 2 != 0)
        {
            return _sorted[_sorted.Length / 2].GetQuality();
        }
        else
        {
            return (_sorted[_sorted.Length / 2].GetQuality() + _sorted[_sorted.Length / 2 - 1].GetQuality()) / 2.0;
        }
    }
    public string[] GetStat()
    {
        return [$"Высшее качество: {MaxQuality()}", $"Минимальное качество: {MinQuality()}", $"Среднее качество: {AverrageQuality()}", $"Медианное значение: {MedianQuality()}"];
    }

    public void PrintStatistic(){
        Console.WriteLine("Вывод статистики:");
        Console.WriteLine();
        Console.WriteLine("Высшее качество продукта: " + MaxQuality());
        Console.WriteLine("Среднее качество продуктов: " + AverrageQuality());
        Console.WriteLine("Медианное качество продуктов:" + MedianQuality());
        Console.WriteLine("Минимальное качество продуктов: " + MinQuality());
        Console.WriteLine();
    }

}