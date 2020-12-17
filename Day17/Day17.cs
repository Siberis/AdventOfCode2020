using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Day17
{
    public static class Day17
    {
        public static decimal Star1(string[] lines, bool fourDimension = false)
        {
            var map = new List<(int w, int z, int y, int x, char c)>();
            var wDim = (0, 0);
            var zDim = (0, 0);
            var yDim = (0, lines.Length - 1);
            var xDim = (0, lines[0].Length - 1);
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    map.Add((0, 0, y, x, lines[y][x]));
                }
            }
            for (int i = 0; i < 6; i++)
            {
                if (fourDimension)
                {
                    wDim = (wDim.Item1 - 1, wDim.Item2 + 1);
                }
                zDim = (zDim.Item1 - 1, zDim.Item2 + 1);
                yDim = (yDim.Item1 - 1, yDim.Item2 + 1);
                xDim = (xDim.Item1 - 1, xDim.Item2 + 1);
                for (int iw = wDim.Item1; iw <= wDim.Item2; iw++)
                {
                    for (int iz = zDim.Item1; iz <= zDim.Item2; iz++)
                    {
                        for (int iy = yDim.Item1; iy <= yDim.Item2; iy++)
                        {
                            for (int ix = xDim.Item1; ix <= xDim.Item2; ix++)
                            {
                                if (
                                    (fourDimension && (iw == wDim.Item1 || iw == wDim.Item2)) ||
                                    iz == zDim.Item1 || iz == zDim.Item2 ||
                                    iy == yDim.Item1 || iy == yDim.Item2 ||
                                    ix == xDim.Item1 || ix == xDim.Item2
                                )
                                {
                                    map.Add((iw, iz, iy, ix, '.'));
                                }
                            }
                        }
                    }
                }
                var actCount = 0;
                var newMap = new List<(int w, int z, int y, int x, char c)>();
                foreach (var (w, z, y, x, c) in map)
                {
                    actCount = 0;
                    foreach (var e in map)
                    {
                        if (w - 1 <= e.w && w + 1 >= e.w &&
                            z - 1 <= e.z && z + 1 >= e.z &&
                            y - 1 <= e.y && y + 1 >= e.y &&
                            x - 1 <= e.x && x + 1 >= e.x &&
                            !(w == e.w && z == e.z && y == e.y && x == e.x) &&
                            e.c == '#')
                        {
                            actCount++;
                        }
                        if (actCount > 3)
                        {
                            break;
                        }
                    }
                    if ((c == '#' && actCount == 2) || actCount == 3)
                    {
                        newMap.Add((w, z, y, x, '#'));
                    }
                    else
                    {
                        newMap.Add((w, z, y, x, '.'));
                    }
                }
                map = newMap;
            }
            return map.Count(e => e.c == '#');
        }
    }
}


