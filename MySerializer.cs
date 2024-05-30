abstract class MySerializer
    {
        public abstract void Write<T>(T products, string filePath);
        public abstract T Read<T>(string filePath);
    }