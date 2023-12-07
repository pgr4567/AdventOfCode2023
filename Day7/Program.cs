using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.IO;
using System.Linq;

namespace Day7
{
    internal class Program
    {
        enum HandType
        {
            Five, Four, FullHouse, Three, TwoPair, OnePair, HighCard
        }
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day7\\input.txt"))
            {
                char[] cards = new char[] { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };
                Dictionary<string, (HandType, int)> hands = new Dictionary<string, (HandType, int)>();
                int sum = 0;
                string[] lines = reader.ReadToEnd().Split('\n');
                for(int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string hand = line.Split(' ')[0];
                    int stake = int.Parse(line.Split(' ')[1]);
                    HandType handType = GetHand(hand);

                    hands.Add(hand, (handType, stake));
                }
                int currentRank = lines.Length;
                foreach (var hand in hands.OrderBy(x => x.Value.Item1).ThenBy(x => GetHandWeight(x.Key, cards)))
                {
                    sum += hand.Value.Item2 * currentRank;
                    currentRank -= 1;
                }
                Console.WriteLine($"Sum is {sum}");
            }
            using (StreamReader reader = new StreamReader("D:\\DEV\\AdventOfCode2023\\Day7\\input.txt"))
            {
                char[] cards = new char[] { 'A', 'K', 'Q', 'T', '9', '8', '7', '6', '5', '4', '3', '2', 'J' };
                Dictionary<string, (HandType, int)> hands = new Dictionary<string, (HandType, int)>();
                int sum = 0;
                string[] lines = reader.ReadToEnd().Split('\n');
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string hand = line.Split(' ')[0];
                    int stake = int.Parse(line.Split(' ')[1]);
                    HandType handType = GetHand2(hand);

                    hands.Add(hand, (handType, stake));
                }
                int currentRank = lines.Length;
                foreach (var hand in hands.OrderBy(x => x.Value.Item1).ThenBy(x => GetHandWeight(x.Key, cards)))
                {
                    sum += hand.Value.Item2 * currentRank;
                    currentRank -= 1;
                }
                Console.WriteLine($"Sum2 is {sum}");
            }
            Console.ReadLine();
        }

        static int GetHandWeight(string hand, char[] cards)
        {
            int weight = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                weight += (int)Math.Pow(15, 4 - i) * Array.IndexOf(cards, hand[i]);
            }
            return weight;
        }

        static HandType GetHand2(string hand)
        {
            char[] cards = new char[] { 'A', 'K', 'Q', 'T', '9', '8', '7', '6', '5', '4', '3', '2', 'J' };

            if (!hand.Contains("J"))
            {
                return GetHand(hand);
            }
            string temp = hand;
            Dictionary<char, HandType> results = new Dictionary<char, HandType>();
            foreach (char c in cards)
            {
                results.Add(c, GetHand(temp.Replace('J', c)));
            }
            return results.OrderBy(x => x.Value).FirstOrDefault().Value;
        }

        static HandType GetHand(string hand)
        {
            Dictionary<char, int> counts = new Dictionary<char, int>();
            foreach(char ch in hand)
            {
                if (!counts.ContainsKey(ch))
                {
                    counts.Add(ch, 0);
                }
                counts[ch] += 1;
            }
            if (counts.Any(p => p.Value == 5))
            {
                return HandType.Five;
            }
            if (counts.Any(p => p.Value == 4))
            {
                return HandType.Four;
            }
            if (counts.Any(p => p.Value == 3) && counts.Any(p => p.Value == 2))
            {
                return HandType.FullHouse;
            }
            if (counts.Any(p => p.Value == 3) && counts.Count == 3)
            {
                return HandType.Three;
            }
            if (counts.Count(p => p.Value == 2) == 2)
            {
                return HandType.TwoPair;
            }
            if (counts.Any(p => p.Value == 2) &&  counts.Count == 4)
            {
                return HandType.OnePair;
            }
            return HandType.HighCard;
        }
    }
}
