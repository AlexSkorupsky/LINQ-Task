using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        public static List<string> ReadFromFile(string fPath)
        {
            StreamReader reader = new StreamReader(new FileStream(fPath, FileMode.Open));
            var list = reader.ReadToEnd().Split(' ').ToList();
            reader.Close();
            return list;
        }

        public static void WriteInFile(string fPath, IEnumerable<string> list)
        {
            StreamWriter writer = new StreamWriter(new FileStream(fPath, FileMode.Create));
            foreach (var item in list)
            {
                writer.Write($"{item} ");
            }
            writer.Close();
        }

        static void Main(string[] args)
        {
            Task1.LinqBegin16();
            Task1.LinqBegin17();
            Task1.LinqBegin18();
            Task1.LinqBegin19();
            Task1.LinqBegin20();

            Task2.LinqBegin44();
            Task2.LinqBegin45();

            Task3.LinqObj1();
        }
    }
}
