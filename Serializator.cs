using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static LR9_13.Serializaztor.Serializator;
using System.Xml.Serialization;
using ProtoBuf;

namespace LR9_13.Serializaztor
{
    internal class Serializator
    {
        public abstract class Serialize
        {
            public abstract T Read<T>(string filePath);
            public abstract void Write<T>(T obj, string filePath);
        }

        public class Xml : Serialize
        {
            public override T Read<T>(string filePath)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    return (T)serializer.Deserialize(fs);

                }
            }
            public override void Write<T>(T obj, string filePath)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    serializer.Serialize(fs, obj);
                }
            }
        }

        public class Json : Serialize
        {
            public override T Read<T>(string filePath)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    return JsonSerializer.Deserialize<T>(fs);
                }
            }
            public override void Write<T>(T obj, string filePath)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize<T>(fs, obj);
                }
            }
        }
        public class Bin : Serialize
        {
            public override T Read<T>(string filePath)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    return Serializer.Deserialize<T>(fs);
                }
            }

            public override void Write<T>(T obj, string filePath)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    Serializer.Serialize(fs, obj);
                }
            }
        }
    }
}
