using System.Text.Json;

class MyJsonSerializer : MySerializer
{
    
    public override T Read<T>(string filePath)
    {
        
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
           return JsonSerializer.Deserialize<T>(fs);
        }
    }

    public override void Write<T>(T products, string filePath)
    {
         using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, products);
            }
    }
}