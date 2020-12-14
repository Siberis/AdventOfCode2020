using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day14
{
    public static class Day14
    {
        public static decimal Star1(string[] lines)
        {
            var mask = "";
            var map = new Dictionary<decimal, decimal>();
            for (int f = 0; f < lines.Length; f++)
            {
                if (lines[f].StartsWith("mask"))
                {
                    mask = lines[f].Split(" = ")[1];
                    continue;
                }
                var f2 = f;
                var map2 = new Dictionary<decimal, decimal>();
                while (f2 < lines.Length && lines[f2].StartsWith("mem"))
                {
                    var parts = lines[f2].Split(" = ");
                    var v = decimal.Parse(parts[1]);
                    var k = decimal.Parse(string.Join("", parts[0].Skip(4).SkipLast(1)));
                    map2[k] = v;
                    f2++;
                }
                f = f2 - 1;
                var m = mask.Reverse().ToArray();
                foreach (var (k, v) in map2)
                {
                    decimal num = 0;
                    decimal tmpV = v;
                    for (int i = 0; i < m.Length; i++)
                    {
                        if (m[i] == 'X')
                        {
                            num += tmpV % 2 * (decimal)Math.Pow(2, i);
                        }
                        else
                        {
                            if (m[i] == '1')
                            {
                                num += (decimal)Math.Pow(2, i);
                            }
                        }
                        tmpV = Math.Floor(tmpV / 2);
                    }
                    map[k] = num;
                }
            }
            decimal sum = 0;
            foreach (var item in map.Values)
            {
                sum += item;
            }
            return sum;
        }
        public static decimal Star2(string[] lines)
        {
            var mask = "";
            var map = new Dictionary<decimal, decimal>();
            var inc = new List<decimal>() { 0 };
            for (int f = 0; f < lines.Length; f++)
            {
                if (lines[f].StartsWith("mask"))
                {
                    inc = new List<decimal>() { 0 };
                    mask = lines[f].Split(" = ")[1];
                    var n = mask.Reverse().ToArray();
                    for (int i = 0; i < n.Length; i++)
                    {
                        if (n[i] == 'X')
                        {
                            var inc2 = new List<decimal>();
                            foreach (var i2 in inc)
                            {
                                inc2.Add(((decimal)Math.Pow(2, i)) + i2);
                            }
                            inc.AddRange(inc2);
                        }
                    }
                    continue;
                }
                var f2 = f;
                var map2 = new Dictionary<decimal, decimal>();
                while (f2 < lines.Length && lines[f2].StartsWith("mem"))
                {
                    var parts = lines[f2].Split(" = ");
                    var v = decimal.Parse(parts[1]);
                    var k = decimal.Parse(string.Join("", parts[0].Skip(4).SkipLast(1)));
                    map2[k] = v;
                    f2++;
                }
                f = f2 - 1;
                var m = mask.Reverse().ToArray();
                foreach (var (k, v) in map2)
                {
                    decimal num = 0;
                    decimal tmpV = k;
                    for (int i = 0; i < m.Length; i++)
                    {
                        if (m[i] == '0')
                        {
                            num += tmpV % 2 * (decimal)Math.Pow(2, i);
                        }
                        else
                        {
                            if (m[i] == '1')
                            {
                                num += (decimal)Math.Pow(2, i);
                            }
                        }
                        tmpV = Math.Floor(tmpV / 2);
                    }
                    foreach (var i2 in inc)
                    {
                        map[i2 + num] = v;
                    }
                }
            }
            decimal sum = 0;
            foreach (var item in map.Values)
            {
                sum += item;
            }
            return sum;
        }
    }
}


