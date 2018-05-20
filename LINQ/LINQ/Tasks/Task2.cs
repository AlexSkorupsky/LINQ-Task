using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Task2
    {
        public static void LinqBegin44()
        {
            StreamReader reader = new StreamReader(new FileStream("data44.txt", FileMode.Open));
            int K1 = Int32.Parse(reader.ReadLine());
            int K2 = Int32.Parse(reader.ReadLine());
            IEnumerable<string> A = reader.ReadLine().Split(' ').ToList();
            IEnumerable<string> B = reader.ReadLine().Split(' ').ToList();
            IEnumerable<string> list1 = A.Where(i => Int32.Parse(i) > K1);
            IEnumerable<string> list2 = B.Where(i => Int32.Parse(i) < K2);
            IEnumerable<string> result = list1.Concat(list2).OrderBy(i => Int32.Parse(i));
            StreamWriter writer = new StreamWriter(new FileStream("output44.txt", FileMode.Create));
            foreach (var i in result)
            {
                writer.Write($"{i} ");
            }
            reader.Close();
            writer.Close();
        }

        public static void LinqBegin45()
        {
            StreamReader reader = new StreamReader(new FileStream("data45.txt", FileMode.Open));
            int L1 = Int32.Parse(reader.ReadLine());
            int L2 = Int32.Parse(reader.ReadLine());
            IEnumerable<string> A = reader.ReadLine().Split(' ').ToList();
            IEnumerable<string> B = reader.ReadLine().Split(' ').ToList();
            IEnumerable<string> list1 = A.Where(x => x.Length == L1);
            IEnumerable<string> list2 = B.Where(x => x.Length == L2);
            IEnumerable<string> result = list1.Concat(list2).OrderByDescending(i => i);
            StreamWriter writer = new StreamWriter(new FileStream("output45.txt", FileMode.Create));
            foreach (var i in result)
            {
                writer.Write($"{i} ");
            }
            reader.Close();
            writer.Close();
        }
    }
}
