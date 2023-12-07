using System;
using System.IO;
using System.Linq;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] _)
        {
            string[] digits = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day1\\input.txt"))
            {
                int sum = 0;
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    int first = -1;
                    int last = -1;
                    foreach (char c in line)
                    {
                        if (Char.IsDigit(c))
                        {
                            if (first == -1)
                            {
                                first = c - '0';
                            }
                            last = c - '0';
                        }
                    }
                    sum += first * 10 + last;
                }
                Console.WriteLine($"Sum: {sum}");
            }
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day1\\input.txt"))
            {
                int sum = 0;
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    int first = -1;
                    int last = -1;
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (Char.IsDigit(line[i]))
                        {
                            if (first == -1)
                            {
                                first = line[i] - '0';
                            }
                            last = line[i] - '0';
                            continue;
                        }
                        int length = 1;
                        string current = "" + line[i];
                        while (digits.Any(d => d.StartsWith(current)) && !digits.Any(d => d == current) && i + length < line.Length)
                        {
                            current += line[i + length];
                            length += 1;
                        }
                        int index = Array.IndexOf(digits, current);
                        if (index != -1)
                        {
                            if (first == -1)
                            {
                                first = index + 1;
                            }
                            last = index + 1;
                        }
                    }
                    sum += first * 10 + last;
                }
                Console.WriteLine($"Sum2: {sum}");
            }
            Console.ReadLine();
        }
    }
}
