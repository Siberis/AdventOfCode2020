using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day7
{
    public class Day7
    {

        public static int Star1(string[] rules)
        {
            Dictionary<string, List<(string, int)>> map = Extract(rules);
            var counter = 0;
            foreach (var item in map.Keys)
            {
                if (!item.Equals("shiny gold"))
                {
                    if (Count(map, item) > 0)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }
        public static int Star2(string[] rules)
        {
            Dictionary<string, List<(string, int)>> map = Extract(rules);
            return Sum(map, "shiny gold");
        }

        private static Dictionary<string, List<(string, int)>> Extract(string[] rules)
        {
            Dictionary<string, List<(string, int)>> map = new Dictionary<string, List<(string, int)>>();
            foreach (var rule in rules)
            {
                var parts = rule.Split("bags contain");
                var key = parts[0].Trim();
                var target = parts[1].Trim().Split(",").Select(e => e.Trim()).Where(e => !"no other bags.".Equals(e)).ToArray();
                if (target.Length > 0)
                {
                    foreach (var t in target)
                    {
                        var count = int.Parse(t.Split(" ")[0]);
                        var res = string.Join(" ", t.Split(" ")[1..^1]);
                        if (!map.ContainsKey(key))
                        {
                            map.Add(key, new List<(string, int)>());
                        }
                        map[key].Add((res, count));
                    }
                }
            }

            return map;
        }

        public static int Count(Dictionary<string, List<(string, int)>> map, string start)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(start);
            var counter = 0;
            while (queue.Count > 0)
            {
                var x = queue.Dequeue();
                if (x.Equals("shiny gold"))
                {
                    counter++;
                    continue;
                }
                if (map.ContainsKey(x))
                {
                    foreach (var item in map[x])
                    {
                        queue.Enqueue(item.Item1);
                    }
                }
            }
            return counter;
        }
        public static int Sum(Dictionary<string, List<(string, int)>> map, string start)
        {
            Queue<(string, List<int>)> queue = new Queue<(string, List<int>)>();
            queue.Enqueue((start, new List<int>() { 1 }));
            var counter = 0;
            while (queue.Count > 0)
            {
                var x = queue.Dequeue();
                if (map.ContainsKey(x.Item1))
                {
                    var sum = 1;
                    foreach (var item in x.Item2)
                    {
                        sum *= item;
                    }
                    counter += sum;
                    foreach (var item in map[x.Item1])
                    {
                        var v = new List<int>(x.Item2);
                        v.Add(item.Item2);
                        queue.Enqueue((item.Item1, v));
                    }
                }
                else
                {
                    var sum = 1;
                    foreach (var item in x.Item2)
                    {
                        sum *= item;
                    }
                    counter += sum;
                }
            }
            return counter - 1;
        }
    }
}


