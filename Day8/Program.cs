using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    internal class Program
    {
        static long LCM(IEnumerable<long> numbers)
        {
            return numbers.Aggregate(LCM);
        }

        static long LCM(long a, long b)
        {
            return Math.Abs(a * b) / GCD(a, b);
        }

        static long GCD(long a, long b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day8\\input.txt"))
            {
                int steps = 0;
                string allText = reader.ReadToEnd();
                string moves = allText.Split(new string[] { "\n\n" }, StringSplitOptions.None)[0];
                string[] rest = allText.Split(new string[] { "\n\n" }, StringSplitOptions.None)[1].Split('\n');
                Dictionary<string, string[]> targets = rest.ToDictionary(x => x.Split('=')[0].Trim(),
                                  x => x.Split('=')[1].Trim()
                                        .Replace("(", string.Empty)
                                        .Replace(")", string.Empty)
                                        .Split(new string[] { ", " }, StringSplitOptions.None));

                string currentPosition = "AAA";
                int currentMove = 0;
                while (currentPosition != "ZZZ")
                {
                    int moveIndex = moves[currentMove] == 'L' ? 0 : 1;
                    currentPosition = targets[currentPosition][moveIndex];
                    currentMove += 1;
                    currentMove %= moves.Length;
                    steps += 1;
                }

                Console.WriteLine($"Sum is {steps}");
            }
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day8\\input.txt"))
            {
                string allText = reader.ReadToEnd();
                string moves = allText.Split(new string[] { "\n\n" }, StringSplitOptions.None)[0];
                string[] rest = allText.Split(new string[] { "\n\n" }, StringSplitOptions.None)[1].Split('\n');
                Dictionary<string, string[]> targets = rest.ToDictionary(x => x.Split('=')[0].Trim(),
                                  x => x.Split('=')[1].Trim()
                                        .Replace("(", string.Empty)
                                        .Replace(")", string.Empty)
                                        .Split(new string[] { ", " }, StringSplitOptions.None));

                List<string> currentPositions = targets.Keys.Where(x => x.EndsWith("A")).ToList();
                List<List<long>> stepsToZ = new List<List<long>>();

                foreach (string position in currentPositions)
                {
                    List<long> currentStepList = new List<long>();
                    List<string> foundZs = new List<string>();
                    
                    string currentPosition = position;
                    int currentMove = 0;
                    while (true)
                    {
                        long currentSteps = 0;
                        while (currentSteps == 0 || !currentPosition.EndsWith("Z"))
                        {
                            int moveIndex = moves[currentMove] == 'L' ? 0 : 1;
                            currentPosition = targets[currentPosition][moveIndex];
                            currentMove += 1;
                            currentMove %= moves.Length;
                            currentSteps += 1;
                        }
                        currentStepList.Add(currentSteps);
                        if (foundZs.Contains(currentPosition))
                        {
                            break;
                        }
                        foundZs.Add(currentPosition);
                    }
                    
                    stepsToZ.Add(currentStepList);
                }
                Console.WriteLine($"Sum2 is {LCM(stepsToZ.Select(x => x[0]))}");
            }
            Console.ReadLine();
        }
    }
}
