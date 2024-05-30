partial class FoodQualityAnalyzer
{
    public static FoodQualityAnalyzer SortByQuality(FoodQualityAnalyzer analyzer)
    {
        FoodProduct temp;
        for (int i = 0; i < analyzer._products.Length; i++)
        {
            for (int j = i + 1; j < analyzer._products.Length; j++)
            {
                if (analyzer._products[i].GetQuality() > analyzer._products[j].GetQuality())
                {
                    temp = analyzer._products[i];
                    analyzer._products[i] = analyzer._products[j];
                    analyzer._products[j] = temp;
                }
            }
        }
        return analyzer;
    }
    public static FoodQualityAnalyzer SortByQualityDesc(FoodQualityAnalyzer analyzer)
    {
        FoodProduct temp;
        for (int i = 0; i < analyzer._products.Length; i++)
        {
            for (int j = i + 1; j < analyzer._products.Length; j++)
            {
                if (analyzer._products[i].GetQuality() < analyzer._products[j].GetQuality())
                {
                    temp = analyzer._products[i];
                    analyzer._products[i] = analyzer._products[j];
                    analyzer._products[j] = temp;
                }
            }
        }
        return analyzer;
    }
    public static FoodQualityAnalyzer SortByName(FoodQualityAnalyzer analyzer)
    {
        FoodProduct temp;
        for (int i = 0; i < analyzer._products.Length; i++)
        {
            for (int j = i + 1; j < analyzer._products.Length; j++)
            {
                if (analyzer._products[i] > analyzer._products[j])
                {
                    temp = analyzer._products[i];
                    analyzer._products[i] = analyzer._products[j];
                    analyzer._products[j] = temp;
                }
            }
        }
        return analyzer;
    }
    public static FoodQualityAnalyzer SortByNameDesc(FoodQualityAnalyzer analyzer)
    {
        FoodProduct temp;
        for (int i = 0; i < analyzer._products.Length; i++)
        {
            for (int j = i + 1; j < analyzer._products.Length; j++)
            {
                if (analyzer._products[i] < analyzer._products[j])
                {
                    temp = analyzer._products[i];
                    analyzer._products[i] = analyzer._products[j];
                    analyzer._products[j] = temp;
                }
            }
        }
        return analyzer;
    }
}