using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day13
{
    public static class Day13
    {
        public static int Star1(string[] lines)
        {
            int time = int.Parse(lines[0]);
            var entries = lines[1].Split(',').Where(e => e[0] != 'x').Select(e => int.Parse(e)).ToList();
            var minTime = int.MaxValue;
            var minId = 0;
            foreach (var entry in entries)
            {
                var diff = entry - (time % entry);
                if (diff < minTime)
                {
                    minTime = diff;
                    minId = entry;
                }
            }
            return minTime * minId;
        }

        public static decimal Star2(string[] input)
        {
            var r = Regex.Matches(input[1], @"(\d+|x)").Select(x => x.Groups[1].Value).ToList();
            List<(decimal, decimal)> busses = new();
            for (int i = 0; i < r.Count; i++)
            {
                if (!r[i].Equals("x"))
                {
                    busses.Add((i, decimal.Parse(r[i])));
                }
            }
            return Compute(busses);
        }

        public static decimal Compute(List<(decimal, decimal)> busses)
        {
            var b1 = busses[0];
            decimal first = default;
            int i;
            for (i = 0; i < busses.Count - 1; i++)
            {
                const decimal mult = 1;
                first = FindFirst(busses, i, mult, b1, b1.Item1);
                decimal next = FindFirst(busses, i, mult, b1, first) - first;
                b1 = (first, next);
            }
            return first;
        }

        private static decimal FindFirst(List<(decimal, decimal)> busses, int i, decimal mult, (decimal, decimal) b1, decimal start = 0)
        {
            while (((b1.Item2 * mult) + busses[i + 1].Item1 + start) % busses[i + 1].Item2 != 0)
            {
                mult++;
            }
            return (b1.Item2 * mult) + start;
        }
    }
}



