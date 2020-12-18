using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Day18
{
    public static class Day18
    {
        public static decimal Star1(string[] lines)
        {
            decimal sum = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                var l = lines[i];
                l = l.Replace("(", " ( ");
                l = l.Replace(")", " ) ");
                var parts = l.Split(" ").Select(e => e.Trim()).Where(e => e.Length > 0).ToArray();
                var (c, _) = Calculate(parts, 0, parts.Length);
                sum += c;
            }
            return sum;
        }
        public static (decimal, int) Calculate(string[] parts, int index, int max)
        {
            decimal acc = -1;
            decimal b = -1;
            var op = "";
            for (int i = index; i < max; i++)
            {
                if (parts[i] == "(")
                {
                    var (x, ni) = Calculate(parts, i + 1, max);
                    Process(ref acc, ref b, ref op, x);
                    i = ni;
                }
                else
                if (parts[i] == ")")
                {
                    return (acc, i);
                }
                else
                if (parts[i] == "+")
                {
                    op = parts[i];
                }
                else
                if (parts[i] == "*")
                {
                    op = parts[i];
                }
                else
                {
                    var x = decimal.Parse(parts[i]);
                    Process(ref acc, ref b, ref op, x);
                }

            }
            return (acc, max);
        }
        public static decimal Star2(string[] lines)
        {
            decimal sum = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                var l = lines[i];
                l = l.Replace("(", " ( ");
                l = l.Replace(")", " ) ");
                var parts = l.Split(" ").Select(e => e.Trim()).Where(e => e.Length > 0).ToList();
                var (c, _) = Calculate2(parts, 0, parts.Count);
                sum += c;
            }
            return sum;
        }
        public static (decimal, int) Calculate2(List<string> parts, int index, int max)
        {
            decimal acc = -1;
            decimal b = -1;
            var op = "";
            for (int i = index; i < max && i < parts.Count; i++)
            {
                if (parts[i] == "+")
                {
                    int start;
                    int end;
                    if (parts[i - 1] == ")")
                    {
                        start = FindIndexMatchOpenPar(parts, i);
                        var count = i - 1 - start + 1;
                        var (x, l) = Calculate2(parts.Skip(start).Take(count).ToList(), 0, count);
                        Process(ref acc, ref b, ref op, x);
                        parts.RemoveRange(start, count);
                        parts.Insert(start, x.ToString());
                        max -= l;
                        i -= l - 1;
                    }
                    if (parts[i + 1] == "(")
                    {
                        end = FindMatchIndexClosePar(parts, i);
                        int count = end - (i + 1) + 1;
                        var (x, l) = Calculate2(parts.Skip(i + 1).Take(count).ToList(), 0, count);
                        Process(ref acc, ref b, ref op, x);
                        parts.RemoveRange(i + 1, end - (i + 1) + 1);
                        parts.Insert(i + 1, x.ToString());
                        max -= l;
                    }

                    op = parts[i];
                    acc = decimal.Parse(parts[i - 1]) + decimal.Parse(parts[i + 1]);
                    parts.RemoveAt(i + 1);
                    parts.RemoveAt(i);
                    parts[i - 1] = acc.ToString();
                    acc = -1;
                    i = 0;
                }
            }
            if (parts.Count == 1)
            {
                return (decimal.Parse(parts[0]), max);
            }

            var tmpArr = parts.Skip(index).Take(Math.Min(max, parts.Count) - index + 1).ToList();
            return Calculate(tmpArr.ToArray(), 0, tmpArr.Count);

        }

        private static int FindIndexMatchOpenPar(List<string> parts, int i)
        {
            int start;
            var open = 0;
            for (start = i - 1; start >= 0; start--)
            {
                if (parts[start] == ")")
                {
                    open++;
                }
                else if (parts[start] == "(")
                {
                    open--;
                }
                if (open == 0)
                {
                    break;
                }
            }

            return start;
        }
        private static int FindMatchIndexClosePar(List<string> parts, int i)
        {
            int end;
            var open = 0;
            for (end = i + 1; end < parts.Count; end++)
            {
                if (parts[end] == "(")
                {
                    open++;
                }
                else if (parts[end] == ")")
                {
                    open--;
                }
                if (open == 0)
                {
                    break;
                }
            }

            return end;
        }

        private static void Process(ref decimal acc, ref decimal b, ref string op, decimal x)
        {
            if (acc == -1)
            {
                acc = x;
            }
            else
            {
                b = x;
            }
            if (b != -1 && op != "")
            {
                acc = op switch
                {
                    "+" => acc + b,
                    "*" => acc * b,
                    _ => acc
                };
                b = -1;
                op = "";
            }
        }
    }
}


