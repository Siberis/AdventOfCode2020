using System;
using System.Linq;

namespace Day3
{
    public static class Day3
    {
        public static int Star1(string[] input, int x, int y)
        {
            var counter = 0;
            var posX = 0;
            for (int i = 0; i < input.Length; i += y)
            {
                if (input[i][posX] == '#')
                {
                    counter++;
                }
                posX = (posX + x) % input[i].Length;
            }
            return counter;
        }
    }
}


