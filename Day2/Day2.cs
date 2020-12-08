using System;
using System.Linq;

namespace Day2
{
    public static class Day2
    {
        public static int Star1(string[] input)
        {
            var counter = 0;
            foreach (var i in input)
            {
                var parts = i.Split(" ");
                var border = parts[0].Split("-").Select(e => int.Parse(e)).ToArray();
                var ch = parts[1].Substring(0, 1);
                var text = parts[2];
                var num = text.Count(c => c == ch[0]);
                if (num >= border[0] && num <= border[1])
                {
                    counter++;
                }
            }
            return counter;
        }
        public static int Star2(string[] input)
        {
            var counter = 0;
            foreach (var i in input)
            {
                var parts = i.Split(" ");
                var border = parts[0].Split("-").Select(e => int.Parse(e)).ToArray();
                var ch = parts[1].Substring(0, 1);
                var text = parts[2];
                if (text[border[0] - 1] == ch[0] ^ text[border[1] - 1] == ch[0])
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}


