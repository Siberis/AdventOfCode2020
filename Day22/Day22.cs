using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Day22
{
    public static class Day22
    {
        public static decimal Star1(string[] lines)
        {
            int player = -1;
            var decks = new List<Queue<int>>();
            decks.Add(new Queue<int>());
            decks.Add(new Queue<int>());
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("Player"))
                {
                    player++;
                    continue;
                }
                if (lines[i].Trim().Length == 0)
                {
                    continue;
                }
                decks[player].Enqueue(int.Parse(lines[i].Trim()));
            }
            while (decks[0].Count != 0 && decks[1].Count != 0)
            {
                var a = decks[0].Dequeue();
                var b = decks[1].Dequeue();
                if (a > b)
                {
                    decks[0].Enqueue(a);
                    decks[0].Enqueue(b);
                }
                else
                {
                    decks[1].Enqueue(b);
                    decks[1].Enqueue(a);
                }
            }
            var win = decks[0].Count == 0 ? decks[1].ToList() : decks[0].ToList();
            decimal sum = 0;
            int pos = 1;
            for (int i = win.Count - 1; i >= 0; i--)
            {
                sum += pos * win[i];
                pos++;
            }
            return sum;
        }
        public static decimal Star2(string[] lines)
        {
            Queue<int>[] decks = PrepareDecs(lines);
            var winIdx = GetWinner(decks);
            var win = decks[winIdx].ToList();
            decimal sum = 0;
            decimal pos = 1;
            for (int i = win.Count - 1; i >= 0; i--)
            {
                sum += pos * ((decimal)win[i]);
                pos++;
            }
            return sum;
        }

        private static int GetWinner(Queue<int>[] decks)
        {
            var memo = new HashSet<string>();
            while (decks[0].Count != 0 && decks[1].Count != 0)
            {
                var key = string.Join(",", decks[0].Concat(new List<int> { -1 }).Concat(decks[1]));
                if (memo.Contains(key))
                {
                    return 0;
                }
                else
                {
                    memo.Add(key);
                }
                var a = decks[0].Dequeue();
                var b = decks[1].Dequeue();
                var idx = 0;
                if (a <= decks[0].Count && b <= decks[1].Count)
                {
                    var newDecks = new Queue<int>[2]{
                        new Queue<int>(decks[0].Take(a)),
                        new Queue<int>(decks[1].Take(b))
                    };
                    idx = GetWinner(newDecks);
                }
                else
                {
                    idx = a > b ? 0 : 1;
                }

                if (idx == 0)
                {
                    decks[0].Enqueue(a);
                    decks[0].Enqueue(b);
                }
                else
                {
                    decks[1].Enqueue(b);
                    decks[1].Enqueue(a);
                }

            }
            return decks[0].Count == 0 ? 1 : 0;
        }

        private static Queue<int>[] PrepareDecs(string[] lines)
        {
            int player = -1;
            var decks = new Queue<int>[2];
            decks[0] = (new Queue<int>());
            decks[1] = (new Queue<int>());
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("Player"))
                {
                    player++;
                    continue;
                }
                if (lines[i].Trim().Length == 0)
                {
                    continue;
                }
                decks[player].Enqueue(int.Parse(lines[i].Trim()));
            }

            return decks;
        }
    }
}


