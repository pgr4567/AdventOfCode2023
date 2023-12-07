using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day5
{
    internal class Program
    {
        enum Type
        {
            Seed = 0, Soil = 1, Fertilizer = 2, Water = 3, Light = 4, Temperature = 5, Humidity = 6, Location = 7
        }
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day5\\input.txt"))
            {
                string text = reader.ReadToEnd();
                long[] seeds = text.Split('\n')[0].Trim().Split(' ').Skip(1).Select(x => long.Parse(x)).ToArray();
                List<List<string>> mapStrings = text.Split(new string[] { "\n\n" }, StringSplitOptions.None)
                    .Skip(1)
                    .Select(x => x
                        .Split(' ')
                        .Skip(1).ToList()).ToList();

                List<List<long>> maps = new List<List<long>>();

                for (int mapId = 0; mapId < mapStrings.Count; mapId++)
                {
                    maps.Add(new List<long>());
                    for (int i = 0; i < mapStrings[mapId].Count; i++)
                    {
                        if (i == 0)
                        {
                            maps[mapId].Add(long.Parse(mapStrings[mapId][i].Substring(4)));
                        }
                        else
                        {
                            string[] longs = mapStrings[mapId][i].Split('\n').Where(x => x.Trim() != "").ToArray();
                            foreach (string s in longs)
                            {
                                maps[mapId].Add(long.Parse(s));
                            }
                        }
                    }
                }

                long lowest = long.MaxValue;
                foreach (long seed in seeds)
                {
                    long location = getCategory(Type.Location, Type.Seed, seed, maps);
                    if (location < lowest)
                    {
                        lowest = location;
                    }
                }
                Console.WriteLine($"Lowest is {lowest}");
            }
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day5\\input.txt"))
            {
                string text = reader.ReadToEnd();
                long[] seeds = text.Split('\n')[0].Trim().Split(' ').Skip(1).Select(x => long.Parse(x)).ToArray();
                List<List<string>> mapStrings = text.Split(new string[] { "\n\n" }, StringSplitOptions.None)
                    .Skip(1)
                    .Select(x => x
                        .Split(' ')
                        .Skip(1).ToList()).ToList();

                List<List<long>> maps = new List<List<long>>();

                for (int mapId = 0; mapId < mapStrings.Count; mapId++)
                {
                    maps.Add(new List<long>());
                    for (int i = 0; i < mapStrings[mapId].Count; i++)
                    {
                        if (i == 0)
                        {
                            maps[mapId].Add(long.Parse(mapStrings[mapId][i].Substring(4)));
                        }
                        else
                        {
                            string[] longs = mapStrings[mapId][i].Split('\n').Where(x => x.Trim() != "").ToArray();
                            foreach (string s in longs)
                            {
                                maps[mapId].Add(long.Parse(s));
                            }
                        }
                    }
                }

                long lowest = long.MaxValue;
                for (int i = 0; i < seeds.Length; i += 2)
                {
                    long start = seeds[i];
                    long length = seeds[i + 1];
                    for (long seed = start; seed < start + length; seed++)
                    {
                        long location = getCategory(Type.Location, Type.Seed, seed, maps);
                        if (location < lowest)
                        {
                            lowest = location;
                        }
                    }
                }
                Console.WriteLine($"Lowest2 is {lowest}");
            }
            Console.ReadLine();
        }
        static long getCategory(Type destination, Type source, long input, List<List<long>> data)
        {
            if (destination == source)
            {
                return input;
            }
            List<long> conversions = data[(int)source];
            for (int i = 0; i < conversions.Count; i += 3)
            {
                long destinationStart = conversions[i];
                long sourceStart = conversions[i + 1];
                long length = conversions[i + 2];

                if (input >= sourceStart && input < sourceStart + length)
                {
                    long result = destinationStart + (input - sourceStart);
                    return getCategory(destination, source + 1, result, data);
                }
            }
            return getCategory(destination, source + 1, input, data);
        }
    }
}
