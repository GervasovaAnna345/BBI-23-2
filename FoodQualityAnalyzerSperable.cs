
using System.Collections;
using System.Xml.Serialization;


partial class FoodQualityAnalyzer : ISpreadable
 {  
    private FoodProduct[] _products = { };
    public FoodProduct[] Products { get { return _products; } }
    
    public FoodQualityAnalyzer(FoodProduct[] products)
    {
        _products = products;
    }
    public FoodQualityAnalyzer()
    {
       
    }


    public void AddProduct(FoodProduct product)
    {
        _products = _products.Append(product).ToArray();
    }

   
    public void AddProduct(FoodProduct product, int count)
    {
        for(int i = 0; i < count; i++){
            _products = _products.Append(product).ToArray();
        }
    }

    public void RemoveProduct(FoodProduct product)
    {
        FoodProduct[] products_temp = { };
        bool deleted = false;
        foreach (var pr in _products)
        {
            if (pr != product)
            {
                products_temp = products_temp.Append(pr).ToArray();
            }
            else if (deleted == true)
            {
                products_temp = products_temp.Append(pr).ToArray();
            }
            else { deleted = true; }
        }
        _products = products_temp;
    }
    public void RemoveProduct(FoodProduct product, int count)
    {
        FoodProduct[] products_temp = { };
        foreach (var pr in _products)
        {
            if (pr != product)
            {
                products_temp = products_temp.Append(pr).ToArray();
            }
            else if (count == 0)
            {
                products_temp = products_temp.Append(pr).ToArray();
            }
            else { count--; }
        }
        _products = products_temp;
    }

    public IEnumerator GetEnumerator() => _products.GetEnumerator();
}