using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day15
{
    public static class Day15
    {
        public static int Star1(int[] numbers, int which)
        {
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!dict.ContainsKey(numbers[i]))
                {
                    dict[numbers[i]] = new List<int>();
                }
                dict[numbers[i]].Add(i + 1);
            }
            var prev = numbers[^1];
            for (int i = numbers.Length + 1; i <= which; i++)
            {
                var list = dict[prev].TakeLast(2).ToList();
                if (list.Count == 2)
                {
                    var x = Math.Abs(list[0] - list[1]);
                    prev = x;
                    if (!dict.ContainsKey(x))
                    {
                        dict[x] = new List<int>();
                    }
                    dict[x].Add(i);
                }
                else if (list.Count == 1)
                {
                    var x = list[0] - (i - 1);
                    prev = x;
                    if (!dict.ContainsKey(x))
                    {
                        dict[x] = new List<int>();
                    }
                    dict[x].Add(i);
                }
                else
                {
                    const int x = 0;
                    prev = x;
                    if (!dict.ContainsKey(x))
                    {
                        dict[x] = new List<int>();
                    }
                    dict[x].Add(i);
                }
            }
            return prev;
        }
    }
}



