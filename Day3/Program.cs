using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day3\\input.txt"))
            {
                int sum = 0;
                string text = reader.ReadToEnd();
                string[] lines = text.Split('\n');
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    string line = lines[i];
                    Match match = Regex.Match(line, @"\d+");
                    while (match.Success)
                    {
                        string actualLine = line.Substring(Math.Max(match.Index - 1, 0), Math.Min(match.Length + 2, line.Length - match.Index));
                        if (i > 0)
                        {
                            actualLine += lines[i - 1].Substring(Math.Max(match.Index - 1, 0), Math.Min(match.Length + 2, line.Length - match.Index));
                        }
                        if (i < lines.Length - 2)
                        {
                            actualLine += lines[i + 1].Substring(Math.Max(match.Index - 1, 0), Math.Min(match.Length + 2, line.Length - match.Index));
                        }
                        Match hasSymbol = Regex.Match(actualLine, @"[^0-9.]");
                        if (hasSymbol.Success) 
                        {
                            sum += int.Parse(match.Value);
                        }

                        match = match.NextMatch();
                    }
                }
                Console.WriteLine($"Sum: {sum}");
            }
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day3\\input.txt"))
            {
                int sum = 0;
                string text = reader.ReadToEnd();
                string[] lines = text.Split('\n');
                Dictionary<Tuple<int, int>, List<int>> gears = new Dictionary<Tuple<int, int>, List<int>>();
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    string line = lines[i];
                    Match match = Regex.Match(line, @"\d+");
                    while (match.Success)
                    {
                        string actualLine = line.Substring(Math.Max(match.Index - 1, 0), Math.Min(match.Length + 2, line.Length - match.Index));
                        string upperLine = "";
                        string lowerLine = "";
                        if (i > 0)
                        {
                            upperLine = lines[i - 1].Substring(Math.Max(match.Index - 1, 0), Math.Min(match.Length + 2, line.Length - match.Index));
                        }
                        if (i < lines.Length - 2)
                        {
                            lowerLine = lines[i + 1].Substring(Math.Max(match.Index - 1, 0), Math.Min(match.Length + 2, line.Length - match.Index));
                        }
                        Match hasSymbol = Regex.Match(actualLine, @"[^0-9.]");
                        if (hasSymbol.Success)
                        {
                            Tuple<int, int> position = Tuple.Create(i, hasSymbol.Index + Math.Max(0, match.Index - 1));
                            if (!gears.ContainsKey(position))
                            {
                                gears.Add(position, new List<int>());
                            }
                            gears[position].Add(int.Parse(match.Value));
                        }
                        else
                        {
                            hasSymbol = Regex.Match(upperLine, @"[^0-9.]");
                            if (hasSymbol.Success)
                            {
                                Tuple<int, int> position = Tuple.Create(i - 1, hasSymbol.Index + Math.Max(0, match.Index - 1));
                                if (!gears.ContainsKey(position))
                                {
                                    gears.Add(position, new List<int>());
                                }
                                gears[position].Add(int.Parse(match.Value));
                            }
                            else
                            {
                                hasSymbol = Regex.Match(lowerLine, @"[^0-9.]");
                                if (hasSymbol.Success)
                                {
                                    Tuple<int, int> position = Tuple.Create(i + 1, hasSymbol.Index + Math.Max(0, match.Index - 1));
                                    if (!gears.ContainsKey(position))
                                    {
                                        gears.Add(position, new List<int>());
                                    }
                                    gears[position].Add(int.Parse(match.Value));
                                }
                            }
                        }

                        match = match.NextMatch();
                    }
                }
                foreach (List<int> ratios in gears.Values)
                {
                    if (ratios.Count == 2)
                    {
                        sum += (ratios[0] * ratios[1]);
                    }
                }
                Console.WriteLine($"Sum2: {sum}");
            }
            Console.ReadLine();
        }
    }
}
