using ProtoBuf;
class MyBinarySerializer : MySerializer
{
    public override T Read<T>(string filepath)
    {
        using (var fs = new FileStream(filepath, FileMode.OpenOrCreate))
        {
            return Serializer.Deserialize<T>(fs);
        }
    }
    public override void Write<T>(T obj, string filepath)
    {
        using (var fs = new FileStream(filepath, FileMode.OpenOrCreate))
        {
            Serializer.Serialize(fs, obj);
        }
    }
}