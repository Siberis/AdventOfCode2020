using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4
{
    public static class Day4
    {
        public static int Star1(string[] input)
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            var require = new HashSet<string>(){
"byr",
"iyr",
"eyr",
"hgt",
"hcl",
"ecl",
"pid"
            };
            var counter = 0;
            foreach (var line in input)
            {
                if (line.Trim().Length == 0)
                {
                    if (!require.Except(fields.Keys).Any())
                    {
                        counter++;
                    }

                    fields = new Dictionary<string, string>();
                    continue;
                }
                foreach (var f in line.Split(" "))
                {
                    var x = f.Split(":");
                    fields.Add(x[0], x[1]);
                }
            }

            if (!require.Except(fields.Keys).Any())
            {
                counter++;
            }
            return counter;
        }

        public static int Star2(string[] input)
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            var require = new HashSet<string>(){
"byr",
"iyr",
"eyr",
"hgt",
"hcl",
"ecl",
"pid"
            };
            var counter = 0;
            foreach (var line in input)
            {
                if (line.Trim().Length == 0)
                {
                    if (!require.Except(fields.Keys).Any())
                    {
                        if (Validate(fields))
                        {
                            counter++;
                        }
                    }

                    fields = new Dictionary<string, string>();
                    continue;
                }
                foreach (var f in line.Split(" "))
                {
                    var x = f.Split(":");
                    fields.Add(x[0], x[1]);
                }
            }

            if (!require.Except(fields.Keys).Any())
            {
                if (Validate(fields))
                {
                    counter++;
                }
            }
            return counter;
        }
        private static bool Validate(Dictionary<string, string> fields)
        {
            var ecl = new HashSet<string>{
                "amb","blu","brn","gry","grn","hzl","oth"
            };
            var tmp = fields["byr"];
            if (!Regex.IsMatch(tmp, "^[0-9]{4}$"))
            {
                return false;
            }
            if (int.Parse(tmp) < 1920 || int.Parse(tmp) > 2002)
            {
                return false;
            }
            tmp = fields["iyr"];
            if (!Regex.IsMatch(tmp, "^[0-9]{4}$"))
            {
                return false;
            }
            if (int.Parse(tmp) < 2010 || int.Parse(tmp) > 2020)
            {
                return false;
            }
            tmp = fields["eyr"];
            if (!Regex.IsMatch(tmp, "^[0-9]{4}$"))
            {
                return false;
            }
            if (int.Parse(tmp) < 2020 || int.Parse(tmp) > 2030)
            {
                return false;
            }
            tmp = fields["pid"];
            if (!Regex.IsMatch(tmp, "^[0-9]{9}$"))
            {
                return false;
            }
            tmp = fields["hcl"];
            if (!Regex.IsMatch(tmp, "^#[0-9a-f]{6}$"))
            {
                return false;
            }
            tmp = fields["ecl"];
            if (!ecl.Contains(tmp))
            {
                return false;
            }
            tmp = fields["hgt"];
            if (!Regex.IsMatch(tmp, "^[0-9]+in$") && !Regex.IsMatch(tmp, "^[0-9]+cm$"))
            {
                return false;
            }
            if (Regex.IsMatch(tmp, "^[0-9]+cm$"))
            {
                tmp = tmp[..^2];
                if (int.Parse(tmp) < 150 || int.Parse(tmp) > 193)
                {
                    return false;
                }
            }
            if (Regex.IsMatch(tmp, "^[0-9]+in$"))
            {
                tmp = tmp[..^2];
                if (int.Parse(tmp) < 59 || int.Parse(tmp) > 76)
                {
                    return false;
                }
            }
            return true;
        }
    }
}


