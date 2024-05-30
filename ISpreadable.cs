interface ISpreadable{
    void AddProduct(FoodProduct product);
    void AddProduct(FoodProduct product, int count);
    void RemoveProduct(FoodProduct product);
    void RemoveProduct(FoodProduct product, int count);
}