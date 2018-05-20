using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Task1
    {
        public static void LinqBegin16()
        {
            List<string> integers = Program.ReadFromFile("data16.txt");
            IEnumerable<string> positiveIntegers = integers.Where(i => Int32.Parse(i) > 0);
            Program.WriteInFile("output16.txt", positiveIntegers);
        }

        public static void LinqBegin17()
        {
            List<string> integers = Program.ReadFromFile("data17.txt");
            IEnumerable<string> result = integers.Where(i => (Int32.Parse(i) % 2 == 1 || Int32.Parse(i) % 2 == -1)).Distinct();
            Program.WriteInFile("output17.txt", result);
        }

        public static void LinqBegin18()
        {
            List<string> integers = Program.ReadFromFile("data18.txt");
            IEnumerable<string> result = integers.OrderBy(i => Int32.Parse(i)).Where(i => ((i.StartsWith("-") == false) && (i.Length == 2)));
            Program.WriteInFile("output18.txt", result);
        }

        public static void LinqBegin19()
        {
            List<string> words = Program.ReadFromFile("data19.txt");
            IEnumerable<string> result = words.OrderBy(w => w.Length).ThenByDescending(w => w);
            Program.WriteInFile("output19.txt", result);
        }

        public static void LinqBegin20()
        {
            StreamReader reader = new StreamReader(new FileStream("data20.txt", FileMode.Open));
            int D = Int32.Parse(reader.ReadLine());
            List<string> integers = reader.ReadToEnd().Split(' ').ToList();
            IEnumerable<string> A = integers.SkipWhile(i => Int32.Parse(i) <= D).Reverse().Where(i => Int32.Parse(i) % 2 == 1);
            StreamWriter writer = new StreamWriter(new FileStream("output20.txt", FileMode.Create));
            foreach (var i in A)
            {
                writer.Write($"{i} ");
            }
            reader.Close();
            writer.Close();
        }
    }
}
