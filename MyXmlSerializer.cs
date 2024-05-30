using System.Xml.Serialization;

class MyXmlSerializer : MySerializer
{
    public override T Read<T>(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            return (T)new XmlSerializer(typeof(T)).Deserialize(fs);
        }
    }

    public override void Write<T>(T products, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            var temp = new XmlSerializer(typeof(T));
                temp.Serialize(fs, products);
        }
    }
}