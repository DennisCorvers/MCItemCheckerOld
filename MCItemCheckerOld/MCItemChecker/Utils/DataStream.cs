using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

namespace MCItemChecker.Utils
{
    static class DataStream
    {
        [Obsolete("BinaryFormatter is obsolete. Use Json instead", false)]
        public static void SaveFileOld(object T, string filepath)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, T);
                stream.Close();
            }
        }

        [Obsolete("BinaryFormatter is obsolete. Use Json instead", false)]
        public static T OpenFileOld<T>(string filepath)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                T file = (T)formatter.Deserialize(stream);
                return file;
            }
        }

        public static void SaveFile<T>(T data, string filePath)
        {
            using (var file = File.Create(filePath))
            {
                ProtoBuf.Serializer.Serialize(file, data);
            }
        }

        public static T OpenFile<T>(string filepath)
        {
            using (var file = File.OpenRead(filepath))
            {
                return ProtoBuf.Serializer.Deserialize<T>(file);
            }
        }

        public static void WriteTextToFile(string[] text, string filePath, bool append = false)
        {
            using (StreamWriter sw = new StreamWriter(filePath, append))
            {
                foreach (string s in text)
                    sw.WriteLine(s);

                sw.Close();
            }
        }

        public static void WriteTextToFile(string text, string filePath, bool append = false)
        {
            using (StreamWriter sw = new StreamWriter(filePath, append))
            {
                sw.Write(text);

                sw.Close();
            }
        }
    }
}

