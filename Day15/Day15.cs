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
            var dict = new int[which, 2];
            for (int i = 0; i < which; ++i)
            {
                dict[i, 0] = -1;
                dict[i, 1] = -1;
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                dict[numbers[i], 0] = -1;
                dict[numbers[i], 1] = i + 1;
            }
            var prev = numbers[^1];
            int x;
            for (int i = numbers.Length + 1; i <= which; i++)
            {
                if (dict[prev, 0] != -1)
                {
                    x = Math.Abs(dict[prev, 1] - dict[prev, 0]);
                }
                else if (dict[prev, 1] != -1)
                {
                    x = dict[prev, 1] - (i - 1);
                }
                else
                {
                    x = 0;
                }
                prev = x;
                if (dict[x, 1] == -1)
                {
                    dict[x, 1] = i;
                }
                else
                {
                    dict[x, 0] = dict[x, 1];
                    dict[x, 1] = i;
                }
            }
            return prev;
        }
    }
}



