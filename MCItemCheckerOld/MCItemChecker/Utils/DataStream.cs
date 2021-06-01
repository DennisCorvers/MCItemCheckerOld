using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MCItemChecker.Utils
{
    static class DataStream
    {
        public static void SaveFile(object T, string filepath)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, T);
                stream.Close();
            }
        }

        public static T OpenFile<T>(string filepath)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                T file = (T)formatter.Deserialize(stream);
                return file;
            }
        }

        public static void WriteTexttoFile(string[] Text, string filepath, bool append = false)
        {
            using (StreamWriter sw = new StreamWriter(filepath, append))
            {
                foreach (string s in Text)
                    sw.WriteLine(s);

                sw.Close();
            }
        }
    }
}

