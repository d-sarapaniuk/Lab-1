using System.IO;

namespace DAL
{
    public static class DB
    {
        private static string path = "C://Users//user//Desktop//НАУ//OOP 2//Laboratory 1//" + "Database.txt";
        public static void write(object obj, string objName)
        {
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fs);

            string objType = obj.GetType().Name;
            streamWriter.WriteLine($"{objType} {objName} \n{{");

            foreach (var prop in obj.GetType().GetProperties())
            {
                streamWriter.WriteLine($"{prop.Name}: {prop.GetValue(obj, null)}");
            }
            streamWriter.Write("}");

            streamWriter.Close();
            fs.Close();
        }

        public static string load()
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fs);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            fs.Close();
            return data;
        }

        public static void clean()
        {
            FileStream fs = new FileStream(path, FileMode.Truncate, FileAccess.Write);
            fs.Close();
        }
    }
}