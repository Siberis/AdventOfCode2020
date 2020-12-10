using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day10
{
    public static class Day10
    {
        public static int Star1(int[] lines)
        {
            var sorted = lines.OrderBy(e => e).ToArray();
            int diff1 = 0;
            int diff3 = 0;
            int curr = 0;
            for (int i = 0; i < sorted.Length; i++)
            {
                if (sorted[i] - curr == 1)
                {
                    diff1++;
                }
                else if (sorted[i] - curr == 3)
                {
                    diff3++;
                }
                curr = sorted[i];
            }
            return diff1 * (diff3 + 1);
        }
        public static decimal Star2(int[] lines)
        {
            var sorted = lines.OrderBy(e => e).ToList();
            sorted.Add(sorted.Max() + 3);
            sorted.Insert(0, 0);
            Dictionary<int, decimal> memo = new Dictionary<int, decimal>();
            return Count(sorted, 0, memo) / 2;
        }
        public static decimal Count(List<int> lines, int start, Dictionary<int, decimal> memo)
        {
            var x = lines[start];
            decimal counter = 0;
            if (memo.ContainsKey(start))
            {
                return memo[start];
            }
            for (int i = start + 1; i < lines.Count; i++)
            {
                if (lines[i] > x + 3)
                {
                    continue;
                }
                if (i == lines.Count - 1)
                {
                    memo[i] = 1;
                    counter++;
                }
                if (memo.ContainsKey(i))
                {
                    counter += memo[i];
                }
                else
                {
                    counter += Count(lines, i, memo);
                }
            }
            memo[start] = counter;
            return memo[start];
        }
    }
}


