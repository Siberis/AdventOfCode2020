using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day6
{
    public static class Day6
    {
        public static int Star1(string[] rules)
        {
            var counter = 0;
            var groupCounter = "";
            foreach (var line in rules)
            {
                if (line.Trim().Length == 0)
                {
                    counter += groupCounter.Distinct().Count();
                    groupCounter = "";
                    continue;
                }
                groupCounter += line.Trim();
            }
            counter += groupCounter.Distinct().Count();
            return counter;
        }
        public static int Star2(string[] rules)
        {
            var counter = 0;
            var groupCounter = new HashSet<char>();
            var groupInnerId = 0;
            foreach (var line in rules)
            {
                if (line.Trim().Length == 0)
                {
                    counter += groupCounter.Distinct().Count();
                    groupCounter = new HashSet<char>();
                    groupInnerId = 0;
                    continue;
                }
                if (groupInnerId == 0)
                {
                    groupCounter = line.Trim().ToHashSet();
                }
                else
                {
                    groupCounter = groupCounter.Intersect(line.Trim().AsEnumerable()).ToHashSet();
                }
                groupInnerId++;
            }
            counter += groupCounter.Distinct().Count();
            return counter;
        }
    }
}


