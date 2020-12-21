using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Day19
{
    public static class Day19
    {
        public static decimal Star1(string[] input)
        {
            var (receivedMessages, rules) = ProcessInput(input);

            return receivedMessages
                .Select(message => GetPotentialStrings(0, rules, message).Contains(message))
                .Count(valid => valid);
        }

        public static decimal Star2(string[] input)
        {
            var (receivedMessages, rules) = ProcessInput(input);

            rules[8] = new DayRule
            {
                Rules = new List<List<int>>
                {
                    new() {42},
                    new() {42, 8}
                }
            };

            rules[11] = new DayRule
            {
                Rules = new List<List<int>>
                {
                    new() {42, 31},
                    new() {42, 11, 31}
                }
            };

            return receivedMessages
                .Select(message => GetPotentialStrings(0, rules, message).Contains(message))
                .Count(valid => valid);
        }

        private static (List<string> receivedMessages, Dictionary<int, DayRule> rules) ProcessInput(IEnumerable<string> input)
        {
            var processedRules = false;
            var receivedMessages = new List<string>();
            var ruleDict = new Dictionary<int, DayRule>();

            foreach (var row in input)
            {
                if (string.IsNullOrWhiteSpace(row))
                {
                    processedRules = true;
                    continue;
                }

                if (!processedRules)
                {
                    var split = row.Split(": ");
                    var ruleNumber = int.Parse(split[0]);

                    if (split[1].Contains("\""))
                    {
                        ruleDict.Add(ruleNumber, new DayRule { Value = split[1].Replace("\"", "") });
                    }
                    else
                    {
                        var rulesStr = split[1].Split("|");
                        var rules = rulesStr
                            .Select(rule =>
                                rule.Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToList())
                            .ToList();

                        ruleDict.Add(ruleNumber, new DayRule { Rules = rules });
                    }
                }
                else
                {
                    receivedMessages.Add(row);
                }
            }

            return (receivedMessages, ruleDict);
        }

        private static IEnumerable<string> GetPotentialStrings(int ruleNumber, IReadOnlyDictionary<int, DayRule> rules, string compare)
        {
            var r = rules[ruleNumber];

            if (r.IsCharacter)
            {
                yield return r.Value;
            }
            else
            {
                foreach (var rule in r.Rules)
                {
                    switch (rule.Count)
                    {
                        case 1:
                            {
                                foreach (var s in GetPotentialStrings(rule[0], rules, compare))
                                {
                                    yield return s;
                                }

                                break;
                            }
                        case 2:
                            {
                                foreach (var left in GetPotentialStrings(rule[0], rules, compare))
                                {
                                    if (!compare.StartsWith(left))
                                    {
                                        continue;
                                    }

                                    foreach (var right in GetPotentialStrings(rule[1], rules, compare.Substring(left.Length)))
                                    {

                                        yield return left + right;
                                    }
                                }

                                break;
                            }
                        case 3:
                            {
                                foreach (var f in GetPotentialStrings(rule[0], rules, compare))
                                {
                                    if (!compare.StartsWith(f))
                                    {
                                        continue;
                                    }

                                    foreach (var s in GetPotentialStrings(rule[1], rules, compare.Substring(f.Length)))
                                    {
                                        if (!compare.StartsWith(f + s))
                                        {
                                            continue;
                                        }

                                        foreach (var t in GetPotentialStrings(rule[2], rules, compare.Substring(f.Length + s.Length)))
                                        {
                                            yield return f + s + t;
                                        }
                                    }
                                }

                                break;
                            }
                        default:
                            throw new ArgumentOutOfRangeException(nameof(rule.Count), "uh-oh");
                    }
                }
            }
        }

        private record DayRule
        {
            public List<List<int>> Rules { get; init; }

            public string Value { get; init; }

            public bool IsCharacter => !string.IsNullOrWhiteSpace(Value);
        }
    }
}