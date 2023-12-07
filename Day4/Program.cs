using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day4\\input.txt"))
            {
                int sum = 0;
                string text = reader.ReadToEnd();
                string[] lines = text.Split('\n');
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    string line = lines[i];
                    string[] data = line.Split(':');
                    int gameId = int.Parse(Regex.Match(data[0], @"\d+").Value);
                    string[] allNumbers = data[1].Split('|');
                    int[] winners = allNumbers[0].Split(' ').Where(s => s.Trim() != "").Select(s => int.Parse(s)).ToArray();
                    int[] numbers = allNumbers[1].Split(' ').Where(s => s.Trim() != "").Select(s => int.Parse(s)).ToArray();

                    int count = 0;
                    foreach (int number in winners) 
                    {
                        if (numbers.Contains(number))
                        {
                            count += 1;
                        }
                    }
                    sum += (int)Math.Pow(2, count - 1);
                }
                Console.WriteLine($"Sum: {sum}");
            }
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day4\\input.txt"))
            {
                string text = reader.ReadToEnd();
                string[] lines = text.Split('\n');
                Dictionary<int, int> cardCounts = new Dictionary<int, int>();
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    string line = lines[i];
                    string[] data = line.Split(':');
                    int gameId = int.Parse(Regex.Match(data[0], @"\d+").Value);
                    string[] allNumbers = data[1].Split('|');
                    int[] winners = allNumbers[0].Split(' ').Where(s => s.Trim() != "").Select(s => int.Parse(s)).ToArray();
                    int[] numbers = allNumbers[1].Split(' ').Where(s => s.Trim() != "").Select(s => int.Parse(s)).ToArray();

                    if (!cardCounts.ContainsKey(gameId)) 
                    {
                        cardCounts.Add(gameId, 0);
                    }
                    cardCounts[gameId]++;

                    int count = 0;
                    foreach (int number in winners)
                    {
                        if (numbers.Contains(number))
                        { 
                            count += 1;
                        }
                    }
                    for (int x = 1; x < count + 1; x++)
                    {
                        if (!cardCounts.ContainsKey(gameId + x))
                        {
                            cardCounts.Add(gameId + x, 0);
                        }
                        cardCounts[gameId + x] += cardCounts[gameId];
                    }
                }
                Console.WriteLine($"Sum2: {cardCounts.Sum(kv => kv.Value)}");
            }
            Console.ReadLine();
        }
    }
}
