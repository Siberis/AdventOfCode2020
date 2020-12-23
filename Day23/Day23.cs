using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Day23
{
    public static class Day23
    {
        public static string Star1(string input)
        {
            //Array approach is deadend in context of performance
            var elems = input.Select(e => decimal.Parse($"{e}")).ToList();
            int current = 0;
            var next = new List<decimal>() { 0, 0, 0 };
            int maxVal = 9;
            for (int round = 0; round < 100; round++)
            {
                var selected = elems[current];
                var i = current + 1;
                i %= elems.Count;
                for (int j = 0; j < 3; j++)
                {
                    i %= elems.Count;
                    next[j] = elems[i];
                    i++;
                }
                var length = elems.Count;
                var dest = selected - 1;
                while (next.Contains(dest) || dest == 0)
                {
                    dest--;
                    if (dest <= 0)
                    {
                        dest = maxVal;
                    }
                }

                var destIdx = elems.IndexOf(dest);
                for (var x = (current + 1 + length) % length; x != destIdx; x = (x + 1) % length)
                {
                    elems[x] = elems[(x + 3) % length];
                }
                destIdx -= 3;
                if (destIdx < 0)
                {
                    destIdx = (destIdx + length) % length;
                }
                elems[(destIdx + 3) % length] = next[2];
                elems[(destIdx + 2) % length] = next[1];
                elems[(destIdx + 1) % length] = next[0];

                current++;
                current %= length;
            }

            var res = "";
            var start = elems.IndexOf(1);
            for (int i = 0; i < elems.Count - 1; i++)
            {
                res += elems[(++start) % elems.Count];
            }
            return res;
        }

        private record Node(decimal Val)
        {
            public Node Next { get; set; }
        };
        public static decimal Star2(string input)
        {
            const int MaxVal = 1_000_000;
            var nodes = new List<Node>();
            var nodesDictionary = new Dictionary<decimal, Node>();
            foreach (decimal i in input.Select(e => decimal.Parse($"{e}")))
            {
                var tmp2 = new Node(i);
                nodes.Add(tmp2);
                nodesDictionary[i] = tmp2;
            }
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Next = nodes[(i + 1) % nodes.Count];
            }

            var cur = nodes[^1];

            for (decimal i = 10; i <= MaxVal; i++)
            {
                cur.Next = new Node(i);
                cur = cur.Next;
                nodesDictionary[i] = cur;
            }
            cur.Next = nodes[0];
            cur = nodes[0];
            for (decimal i = 0; i < 10_000_000; i++)
            {
                var groupStart = cur.Next;
                cur.Next = cur.Next.Next.Next.Next;

                var next = new List<decimal>()
                {
                    groupStart.Val,
                    groupStart.Next.Val,
                    groupStart.Next.Next.Val
                };
                decimal expectedVal = cur.Val == 1 ? MaxVal : cur.Val - 1;
                while (next.Contains(expectedVal))
                {
                    expectedVal--;
                    if (expectedVal < 1) expectedVal = MaxVal;
                }

                var insertPoint = nodesDictionary[expectedVal];

                groupStart.Next.Next.Next = insertPoint.Next;
                insertPoint.Next = groupStart;
                cur = cur.Next;
            }

            return nodesDictionary[1].Next.Val * nodesDictionary[1].Next.Next.Val;
        }
    }
}


