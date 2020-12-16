using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day16
{
    public static class Day16
    {
        public static decimal Star1(string[] lines)
        {
            var i = 0;
            Dictionary<string, List<(int, int)>> categories = ParseCategories(lines, ref i);
            i++;
            List<int> myValues = new List<int>();
            ParseMyTicket(lines, ref i, ref myValues);
            i++;
            var sum = 0;
            while (i < lines.Length && lines[i].Trim().Length != 0)
            {
                if (lines[i].StartsWith("nearby tickets"))
                {
                    i++;
                    continue;
                }
                foreach (var t in lines[i].Split(",").Select(e => int.Parse(e)).ToList())
                {
                    if (categories.Values.SelectMany(e => e).Any(v => v.Item1 <= t && v.Item2 >= t))
                    {
                        continue;
                    }
                    else
                    {
                        sum += t;
                    }
                }
                i++;
            }
            i++;

            return sum;
        }
        public static decimal Star2(string[] lines, string target)
        {
            var i = 0;
            Dictionary<string, List<(int, int)>> categories = ParseCategories(lines, ref i);
            i++;
            List<int> myValues = new List<int>();
            ParseMyTicket(lines, ref i, ref myValues);
            i++;
            var potentials = new Dictionary<int, List<string>>();
            var keys = categories.Keys.ToList();
            var nerby = new List<List<int>>();
            while (i < lines.Length && lines[i].Trim().Length != 0)
            {
                if (lines[i].StartsWith("nearby tickets"))
                {
                    i++;
                    continue;
                }
                var ticket = lines[i].Split(",").Select(e => int.Parse(e)).ToList();

                if (categories.Values.Any(x => ticket.All(v => x.Any(p => p.Item1 <= v && p.Item2 >= v))))
                {
                    nerby.Add(ticket);
                }
                i++;
            }
            for (int y = 0; y < myValues.Count; y++)
            {
                var vals = nerby.Select(v => v[y]);
                for (int x = 0; x < categories.Count; x++)
                {
                    var potential = categories[keys[x]];
                    if (vals.All(v => potential.Any(p => p.Item1 <= v && p.Item2 >= v)))
                    {
                        if (!potentials.ContainsKey(y))
                        {
                            potentials[y] = new List<string>();
                        }
                        potentials[y].Add(keys[x]);
                    }
                }
            }
            while (!potentials.Values.All(e => e.Count == 1))
            {
                potentials.Values.Where(e => e.Count == 1).ToList().ForEach(min =>
                {
                    foreach (var item in potentials)
                    {
                        if (item.Value.Count == 1)
                        {
                            continue;
                        }
                        item.Value.Remove(min[0]);
                    }
                });
            }
            decimal sum = 1;

            for (int x = 0; x < potentials.Count; x++)
            {
                if (potentials[x][0].StartsWith(target))
                {
                    sum *= myValues[x];
                }
            }

            return sum;
        }

        private static void ParseMyTicket(string[] lines, ref int i, ref List<int> myValues)
        {
            while (lines[i].Trim().Length != 0)
            {
                if (lines[i].StartsWith("your ticket"))
                {
                    i++;
                    continue;
                }
                myValues = lines[i].Split(",").Select(e => int.Parse(e)).ToList();
                i++;
            }
        }

        private static Dictionary<string, List<(int, int)>> ParseCategories(string[] lines, ref int i)
        {
            var categories = new Dictionary<string, List<(int, int)>>();
            while (lines[i].Trim().Length != 0)
            {
                var p1 = lines[i].Split(": ");
                if (!categories.ContainsKey(p1[0]))
                {
                    categories.Add(p1[0], new List<(int, int)>());
                }
                p1[1].Split(" or ").ToList().ForEach(e =>
                {
                    var x = e.Split("-");
                    categories[p1[0]].Add((int.Parse(x[0]), int.Parse(x[1])));
                });
                i++;
            }

            return categories;
        }
    }
}


