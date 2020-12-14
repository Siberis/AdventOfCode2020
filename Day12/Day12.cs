using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day12
{
    public static class Day12
    {
        public static int Star1(string[] lines)
        {
            int dir = 0;
            int x = 0;
            int y = 0;
            foreach (var line in lines)
            {
                var s = line[0];
                var dist = int.Parse(line[1..]);
                switch (s)
                {
                    case 'N': x += dist; break;
                    case 'S': x -= dist; break;
                    case 'E': y += dist; break;
                    case 'W': y -= dist; break;
                    case 'L':
                        dir -= dist;
                        if (dir < 0) dir = 360 + dir;
                        break;
                    case 'R':
                        dir += dist;
                        if (dir >= 360) dir -= 360;
                        break;
                    case 'F':
                        switch (dir)
                        {
                            case 0: y += dist; break;
                            case 90: x -= dist; break;
                            case 180: y -= dist; break;
                            case 270: x += dist; break;
                        }
                        break;
                }
            }
            return Math.Abs(x) + Math.Abs(y);
        }
        public static double Star2(string[] lines)
        {
            double startX = 1;
            double startY = 10;

            double x = 0;
            double y = 0;
            foreach (var line in lines)
            {
                var s = line[0];
                var dist = int.Parse(line[1..]);
                switch (s)
                {
                    case 'N': startX += dist; break;
                    case 'S': startX -= dist; break;
                    case 'E': startY += dist; break;
                    case 'W': startY -= dist; break;
                    case 'L':
                        for (int i = 0; i < dist; i += 90)
                        {
                            var tmp = startY;
                            startY = -startX;
                            startX = tmp;
                        }
                        break;
                    case 'R':
                        for (int i = 0; i < dist; i += 90)
                        {
                            var tmp = startY;
                            startY = startX;
                            startX = -tmp;
                        }
                        break;
                    case 'F':
                        y += startY * dist;
                        x += startX * dist;
                        break;
                }
            }
            return Math.Abs(x) + Math.Abs(y);
        }
    }
}


