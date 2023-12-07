using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int redCubesTotal = 12;
            const int greenCubesTotal = 13;
            const int blueCubesTotal = 14;

            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day2\\input.txt"))
            {
                int sum = 0;
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] game = line.Split(':');
                    string id = game[0].Split(new string[] { "Game " }, StringSplitOptions.None)[1];
                    string[] rounds = game[1].Split(';');
                    bool isPossible = true;
                    foreach (string round in rounds)
                    {
                        string[] entries = round.Split(',');

                        foreach (string entry in entries)
                        {
                            if (entry.Contains("blue"))
                            {
                                if (int.Parse(new String(entry.Where(c => Char.IsDigit(c)).ToArray())) > blueCubesTotal) 
                                {
                                    isPossible = false;
                                    break;
                                }
                            }
                            else if (entry.Contains("red"))
                            {
                                if (int.Parse(new String(entry.Where(c => Char.IsDigit(c)).ToArray())) > redCubesTotal)
                                {
                                    isPossible = false;
                                    break;
                                }
                            }
                            else if (entry.Contains("green"))
                            {
                                if (int.Parse(new String(entry.Where(c => Char.IsDigit(c)).ToArray())) > greenCubesTotal)
                                {
                                    isPossible = false;
                                    break;
                                }
                            }
                        }
                        if (!isPossible)
                        {
                            break;
                        }
                    }
                    if (isPossible)
                    {
                        sum += int.Parse(id);
                    }
                }
                Console.WriteLine($"Sum: {sum}");
            }
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day2\\input.txt"))
            {
                int sum = 0;
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] game = line.Split(':');
                    string id = game[0].Split(new string[] { "Game " }, StringSplitOptions.None)[1];
                    string[] rounds = game[1].Split(';');
                    int redMax = 0;
                    int greenMax = 0;
                    int blueMax = 0;
                    foreach (string round in rounds)
                    {
                        string[] entries = round.Split(',');

                        foreach (string entry in entries)
                        {
                            int current = int.Parse(new String(entry.Where(c => Char.IsDigit(c)).ToArray()));
                            if (entry.Contains("blue") && current > blueMax)
                            {
                                blueMax = current;
                            }
                            else if (entry.Contains("red") && current > redMax)
                            {
                                redMax = current;
                            }
                            else if (entry.Contains("green") && current > greenMax)
                            {
                                greenMax = current;
                            }
                        }
                    }
                    sum += (redMax * blueMax * greenMax);
                }
                Console.WriteLine($"Sum2: {sum}");
            }
            Console.ReadLine();
        }
    }
}
