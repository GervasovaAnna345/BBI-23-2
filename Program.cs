using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program
{   
   
    internal class Program
    {
        static int n = 1;
        public static void Main(string[] args)
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
            path = Path.Combine(path, "data");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            FoodProduct apple = new Fruit("Apple", 0.5, DateTime.Now.AddDays(5), "UnderRipe", "Granny Smith");
            FoodProduct carrot = new Vegetable("Carrot", 0.2, DateTime.Now.AddDays(10), "Fresh", "Orange");
            FoodProduct steak = new Meat("Steak", 1.0, DateTime.Now.AddDays(3), "Poor", "Ribeye");
            FoodProduct bread = new Backery("Bread", 0.5, DateTime.Now.AddDays(2), "Fresh", "White");
            FoodQualityAnalyzer analyzer = new FoodQualityAnalyzer();
            MyJsonSerializer jsonSerializer = new MyJsonSerializer();
            MyXmlSerializer xmlSerializer = new MyXmlSerializer();
            MyBinarySerializer binarySerializer = new MyBinarySerializer();
            analyzer.AddProduct(apple);
            jsonSerializer.Write(analyzer.GetStat(), Path.Combine(path, $"raw_data_{n}.json"));
            n++;
            analyzer.AddProduct(carrot, 2);
            jsonSerializer.Write(analyzer.GetStat(), Path.Combine(path, $"raw_data_{n}.json"));
            n++;
            analyzer.AddProduct(steak, 3);
            jsonSerializer.Write(analyzer.GetStat(), Path.Combine(path, $"raw_data_{n}.json"));
            n++;
            analyzer.AddProduct(bread, 4);
            jsonSerializer.Write(analyzer.GetStat(), Path.Combine(path, $"raw_data_{n}.json"));
            n++;
            jsonSerializer.Write(analyzer.GetStat(), Path.Combine(path, $"stat_data_{n}.json"));
            xmlSerializer.Write(analyzer.GetStat(), Path.Combine(path, $"stat_data_{n}.xml"));
            analyzer.RemoveProduct(apple);
            xmlSerializer.Write(analyzer.GetStat(), Path.Combine(path, $"raw_data_{n}.xml"));
            n++;
            analyzer.RemoveProduct(steak, 3);
            xmlSerializer.Write(analyzer.GetStat(), Path.Combine(path, $"raw_data_{n}.xml"));
            n++;
            var res = jsonSerializer.Read<string[]>(Path.Combine(path, "stat_data_5.json"));
            foreach (var item in res) { Console.WriteLine(item); }
            Console.WriteLine();
            res = xmlSerializer.Read<string[]>(Path.Combine(path, "stat_data_5.xml"));
            foreach (var item in res) { Console.WriteLine(item); }
            Console.WriteLine();
            Standart standart1 = new Standart("standart1", new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Standart standart2 = new Standart("standart2", new double[] { 0, 1, 3, 5, 6, 7, 8, 8, 9, 10 });
            analyzer = new FoodQualityAnalyzer();
            analyzer.AddProduct(new FriedMeat("Nuggets", 0.2, DateTime.Now.AddDays(5), "Good", "Chicken", standart1));
            analyzer.AddProduct(new FriedMeat("Beef", 1, DateTime.Now.AddDays(4), "Good", "Beef", standart1));
            analyzer.AddProduct(new FriedMeat("Kebab", 1, DateTime.Now.AddDays(2), "Good", "Pork", standart2));
            analyzer.AddProduct(new FriedMeat("Sausages", 1.5, DateTime.Now.AddDays(3), "Good", "Turkey", standart2));
            binarySerializer.Write(analyzer.GetStat(), Path.Combine(path, $"raw_data_.bin"));
            FoodQualityAnalyzer.SortByQualityDesc(analyzer);
            binarySerializer.Write(analyzer.GetStat(), Path.Combine(path, $"sorted_data.bin"));
            FoodQualityAnalyzer.SortByName(analyzer);
            Console.WriteLine();
            foreach (var prod in analyzer) { Console.WriteLine(prod); Console.WriteLine(); }
            Console.WriteLine();
            res = binarySerializer.Read<string[]>(Path.Combine(path, $"raw_data.bin"));
            foreach (var item in res) { Console.WriteLine(item); }
            Console.WriteLine();
            res = binarySerializer.Read<string[]>(Path.Combine(path, $"sorted_data.bin"));
            foreach (var item in res) { Console.WriteLine(item); }
            Console.WriteLine();
        }
    }
}