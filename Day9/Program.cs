using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day9\\input.txt"))
            {
                long sum = 0;
                string allText = reader.ReadToEnd();
                string[] lines = allText.Split('\n');

                foreach (string line in lines)
                {
                    List<long> values = line.Split(' ').Select(long.Parse).ToList();
                    List<List<long>> differences = new List<List<long>> { values };

                    while (differences.LastOrDefault().Any(x => x != 0))
                    {
                        List<long> prev = differences.LastOrDefault();
                        List<long> diffs = new List<long>();

                        for (int i = 0; i < prev.Count - 1; i++)
                        {
                            diffs.Add(prev[i + 1] - prev[i]);
                        }

                        differences.Add(diffs);
                    }

                    differences.Last().Add(0);
                    for (int i = differences.Count - 2; i >= 0; i--)
                    {
                        List<long> diffs = differences[i];
                        diffs.Add(diffs[diffs.Count - 1] + differences[i + 1].Last());
                    }
                    sum += differences.First().Last();
                }
                
                Console.WriteLine($"Sum is {sum}");
            }
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day9\\input.txt"))
            {
                long sum = 0;
                string allText = reader.ReadToEnd();
                string[] lines = allText.Split('\n');

                foreach (string line in lines)
                {
                    List<long> values = line.Split(' ').Select(long.Parse).ToList();
                    List<List<long>> differences = new List<List<long>> { values };

                    while (differences.LastOrDefault().Any(x => x != 0))
                    {
                        List<long> prev = differences.LastOrDefault();
                        List<long> diffs = new List<long>();

                        for (int i = 0; i < prev.Count - 1; i++)
                        {
                            diffs.Add(prev[i + 1] - prev[i]);
                        }

                        differences.Add(diffs);
                    }

                    differences.Last().Insert(0, 0);
                    for (int i = differences.Count - 2; i >= 0; i--)
                    {
                        List<long> diffs = differences[i];
                        diffs.Insert(0, diffs[0] - differences[i + 1][0]);
                    }
                    sum += differences.First().First();
                }

                Console.WriteLine($"Sum2 is {sum}");
            }
            Console.ReadLine();
        }
    }
}
