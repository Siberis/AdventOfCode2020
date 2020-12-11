using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day11
{
    public static class Day11
    {
        public static int Star1(string[] lines, int max, int depth)
        {
            char[,] array = Parse(lines);
            var array2 = (char[,])array.Clone();
            while (true)
            {
                for (var i = 0; i < lines.Length; i++)
                {
                    for (var j = 0; j < lines[i].Length; j++)
                    {
                        if (array[i, j] == '.')
                        {
                            continue;
                        }
                        char[] dir = new char[8] { '.', '.', '.', '.', '.', '.', '.', '.' };
                        for (int x = 1; x <= depth; x++)
                        {
                            if (dir[0] == '.') dir[0] = i > (x - 1) && j > (x - 1) ? array[i - x, j - x] : '.';
                            if (dir[1] == '.') dir[1] = i > (x - 1) ? array[i - x, j] : '.';
                            if (dir[2] == '.') dir[2] = i > (x - 1) && j < lines[i].Length - x ? array[i - x, j + x] : '.';
                            if (dir[3] == '.') dir[3] = j > (x - 1) ? array[i, j - x] : '.';
                            if (dir[4] == '.') dir[4] = j < lines[i].Length - x ? array[i, j + x] : '.';
                            if (dir[5] == '.') dir[5] = i < lines.Length - x && j > (x - 1) ? array[i + x, j - x] : '.';
                            if (dir[6] == '.') dir[6] = i < lines.Length - x ? array[i + x, j] : '.';
                            if (dir[7] == '.') dir[7] = i < lines.Length - x && j < lines[i].Length - x ? array[i + x, j + x] : '.';
                        }
                        var occup = dir.Sum(e => e == '#' ? 1 : 0);
                        if (array2[i, j] == 'L' && occup == 0)
                        {
                            array2[i, j] = '#';
                        }
                        else if (array2[i, j] == '#' && occup >= max)
                        {
                            array2[i, j] = 'L';
                        }
                    }
                }
                int counter = CountDiff(lines, array, array2);
                if (counter == 0)
                {
                    break;
                }
                array = (char[,])array2.Clone();
            }
            return CountOccup(lines, array);
        }
        private static int CountOccup(string[] lines, char[,] array)
        {
            var count = 0;
            for (var i = 0; i < lines.Length; i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    if (array[i, j] == '#')
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static int CountDiff(string[] lines, char[,] array, char[,] array2)
        {
            var counter = 0;
            for (var i = 0; i < lines.Length; i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    if (array[i, j] != array2[i, j])
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        private static char[,] Parse(string[] lines)
        {
            char[,] array = new char[lines.Length, lines[0].Length];
            for (var i = 0; i < lines.Length; i++)
            {
                for (var j = 0; j < lines[i].Length; j++)
                {
                    array[i, j] = lines[i][j];
                }
            }

            return array;
        }
    }
}


