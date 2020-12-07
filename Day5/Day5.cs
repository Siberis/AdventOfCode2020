using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day5
{
    public class Day5
    {

        public static int Star1(string rules)
        {
            var row = rules[0..7];
            var col = rules[7..];
            int minRow = 0;
            int maxRow = 127;
            int minCol = 0;
            int maxCol = 7;
            int height = 64;
            int width = 4;
            foreach (var r in row)
            {
                if (r == 'F')
                {
                    maxRow -= height;
                }
                else
                if (r == 'B')
                {
                    minRow += height;
                }
                height /= 2;
            }
            foreach (var c in col)
            {
                if (c == 'L')
                {
                    maxCol -= width;
                }
                else
                if (c == 'R')
                {
                    minCol += width;
                }
                width /= 2;
            }
            return minRow * 8 + minCol;
        }
    }
}


