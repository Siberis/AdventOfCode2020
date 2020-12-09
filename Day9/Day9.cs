using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day9
{
    public static class Day9
    {
        public static decimal Star1(decimal[] lines, int length)
        {
            for (int i = length; i < lines.Length; ++i)
            {
                if (Check(lines, length, i))
                {
                    continue;
                }
                else
                {
                    return lines[i];
                }
            }
            return 0;
        }

        public static decimal Star2(decimal[] lines, int length)
        {
            for (int i = length; i < lines.Length; ++i)
            {
                if (Check(lines, length, i))
                {
                    continue;
                }
                else
                {
                    for (int x = 0; x < i; x++)
                    {
                        for (int y = x + 1; y < i; y++)
                        {
                            decimal sum = 0;
                            for (int z = x; z < y; z++)
                            {
                                sum += lines[z];
                                if (sum > lines[i])
                                {
                                    break;
                                }
                                else if (sum == lines[i])
                                {
                                    return lines.Skip(x).Take(z - x).Min() + lines.Skip(x).Take(z - x).Max();
                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }

        private static bool Check(decimal[] lines, int length, int i)
        {
            for (int j = i - length; j < i; j++)
            {
                for (int k = j + 1; k < i; k++)
                {
                    if (lines[j] + lines[k] == lines[i])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}


