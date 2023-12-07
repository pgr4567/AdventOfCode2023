using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day6\\input.txt"))
            {
                string text = reader.ReadToEnd();
                int[] times = text.Split('\n')[0].Split(' ').Skip(1).Where(s => s.Trim() != "").Select(x => int.Parse(x)).ToArray();
                int[] distances = text.Split('\n')[1].Split(' ').Skip(1).Where(s => s.Trim() != "").Select(x => int.Parse(x)).ToArray();

                List<int> result = new List<int>();
                for(int i = 0; i < times.Length; i++)
                {
                    result.Add((int)GetAmountOfPossibilieties(times[i], distances[i]));
                }

                Console.WriteLine($"Product is {result.Aggregate((prev, curr) => prev * curr)}");
            }
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day6\\input.txt"))
            {
                string text = reader.ReadToEnd();
                long time = long.Parse(text.Split('\n')[0].Split(':')[1].Replace(" ", string.Empty));
                long distance = long.Parse(text.Split('\n')[1].Split(':')[1].Replace(" ", string.Empty));

                long amount = GetAmountOfPossibilieties(time, distance);

                Console.WriteLine($"Amount is {amount}");
            }
            Console.ReadLine();
        }
        static long GetAmountOfPossibilieties(long duration, long distance)
        {
            // Function is (duration - x) * x => -x^2 + duration * x
            // distance = -x^2 + duration * x => 0 = -x^2 + duration * x - distance
            double sqrt = Math.Sqrt(Math.Pow(duration, 2) - (4 * distance));
            double first = (duration + sqrt) / 2;
            double second = (duration - sqrt) / 2;
            first = first == Math.Floor(first) ? first - 1 : first;
            second = second == Math.Floor(second) ? second + 1 : second;

            return (long)(Math.Floor(first) - Math.Ceiling(second) + 1);
        }
    }
}
