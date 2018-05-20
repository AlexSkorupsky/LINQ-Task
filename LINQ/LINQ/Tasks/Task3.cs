using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Client
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public int Mounth { get; set; }
        public int TrainingsDuration { get; set; }

        public void InputClient(StreamReader reader)
        {
            var list = reader.ReadLine().Split(' ').ToList().Select(Int32.Parse).ToList();
            this.ID = list[0];
            this.Year = list[1];
            this.Mounth = list[2];
            this.TrainingsDuration = list[3];
        }
    }

    class Task3
    {
        static Client MaxDuration(List<Client> clist)
        {
            int maxDuration = clist.Max(c => c.TrainingsDuration);
            Client clientWithMaxDur = clist.First(c => c.TrainingsDuration == maxDuration);
            return clientWithMaxDur;
        }

        static Client MinDuration(List<Client> clist)
        {
            int minDuration = clist.Min(c => c.TrainingsDuration);
            Client clientWithMinDur = clist.First(c => c.TrainingsDuration == minDuration);
            return clientWithMinDur;
        }
        
        static int YearWithLongestTrainingsDur(List<Client> clist)
        {
            IEnumerable<IGrouping<int, Client>> groupedByYears = clist.GroupBy(c => c.Year);
            IEnumerable<IGrouping<int, Client>> sortedClientsList = groupedByYears.OrderByDescending(g => g.Sum(c => c.TrainingsDuration)).ThenBy(c => c.Min(cl => cl.Year));
            return sortedClientsList.First().Key;
        }

        static SortedDictionary<int, int> TotalTrainingsDuration(List<Client> clist)
        {
            IEnumerable<IGrouping<int, Client>> groupedByID = clist.GroupBy(c => c.ID);
            SortedDictionary<int, int> trainingsDurations = new SortedDictionary<int, int>();
            foreach (IGrouping<int, Client> g in groupedByID)
            {
                int sum = g.Sum(c => c.TrainingsDuration);
                trainingsDurations.Add(g.Key, sum);
            }
            return trainingsDurations;
        }

        static SortedDictionary<int, int> TotalAmountOfMonths(List<Client> clist)
        {
            IEnumerable<IGrouping<int, Client>> groupedByID = clist.GroupBy(c => c.ID);
            SortedDictionary<int, int> totalAmount = new SortedDictionary<int, int>();
            foreach (IGrouping<int, Client> g in groupedByID)
            {
                int count = g.Sum(c => c.Mounth);
                totalAmount.Add(g.Key, count);
            }
            return totalAmount;
        }

        static List<Client> InputClients(StreamReader reader)
        {
            int n = Int32.Parse(reader.ReadLine());
            List<Client> clients = new List<Client>();
            for (int i = 0; i < n; i++)
            {
                Client c = new Client();
                c.InputClient(reader);
                clients.Add(c);
            }
            return clients;
        }

        public static void LinqObj1()
        {
            List<Client> clientsList = InputClients(new StreamReader(new FileStream("clientsData.txt", FileMode.Open)));
            FileStream fileAnswer = new FileStream("clientsOutput.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(fileAnswer);
            writer.WriteLine($"Client with shortest trainings duration: {MinDuration(clientsList).ID}");
            writer.WriteLine($"Client with longest trainings duration: {MaxDuration(clientsList).ID}");
            writer.WriteLine($"Year with the longest amount of trainings durations: {YearWithLongestTrainingsDur(clientsList)}");

            SortedDictionary<int, int> totalTrainingsDur = TotalTrainingsDuration(clientsList);
            writer.WriteLine();
            foreach (var i in totalTrainingsDur)
            {
                writer.WriteLine($"Client ID - {i.Key}, trainings duration - {i.Value}");
            }
            SortedDictionary<int, int> totalAmountOfMonths = TotalAmountOfMonths(clientsList);
            writer.WriteLine();
            foreach (var i in totalAmountOfMonths)
            {
                writer.WriteLine($"Client ID - {i.Key}, amount of months - {i.Value}");
            }
            writer.Close();
        }
    }
}
