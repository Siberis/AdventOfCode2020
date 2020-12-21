using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Day21
{
    public static class Day21
    {
        public static decimal Star1(string[] lines)
        {
            Parse(lines, out List<List<string>> ingrediends, out List<List<string>> allergens);
            HashSet<string> blocked = GetBlocked(ingrediends, allergens).Values.SelectMany(e => e).ToHashSet();
            return ingrediends.SelectMany(e => e).Count(e => !blocked.Contains(e));
        }

        public static string Star2(string[] lines)
        {
            Parse(lines, out List<List<string>> ingrediends, out List<List<string>> allergens);
            Dictionary<string, HashSet<string>> blockMap = GetBlocked(ingrediends, allergens);
            HashSet<string> blocked = blockMap.Values.SelectMany(e => e).ToHashSet();
            while (blockMap.Values.Any(e => e.Count > 1))
            {
                blockMap.Values.Where(e => e.Count == 1).ToList().ForEach(e =>
                {
                    foreach (var val in blockMap)
                    {
                        if (val.Value.Count > 1)
                            val.Value.ExceptWith(e);
                    }
                });
            }
            return string.Join(",", blockMap.OrderBy(e => e.Key).SelectMany(e => e.Value));
        }

        private static void Parse(string[] lines, out List<List<string>> ingrediends, out List<List<string>> allergens)
        {
            var ingrediendsTmp = new List<List<string>>();
            var allergensTmp = new List<List<string>>();
            lines.ToList().ForEach(e =>
            {
                var parts = e[..^1].Split(" (contains ").ToArray();
                var ing = parts[0].Split(" ").Select(e => e.Trim()).ToList();
                var all = parts[1].Split(", ").Select(e => e.Trim()).ToList();
                allergensTmp.Add(all);
                ingrediendsTmp.Add(ing);
            });
            allergens = allergensTmp;
            ingrediends = ingrediendsTmp;
        }

        private static Dictionary<string, HashSet<string>> GetBlocked(List<List<string>> ingrediends, List<List<string>> allergens)
        {
            var blocked = new Dictionary<string, HashSet<string>>();
            while (true)
            {
                var all = allergens.Find(e => e.Count > 0)?.FirstOrDefault();
                if (all == null)
                {
                    break;
                }
                var indexes = allergens.Select((e, i) => e.Contains(all) ? i : -1).Where(e => e != -1).ToList();
                HashSet<string> ing = null;
                for (var i = 0; i < indexes.Count; i++)
                {
                    if (ing == null)
                    {
                        ing = new HashSet<string>();
                        ingrediends[indexes[i]].ForEach(e => ing.Add(e));
                    }
                    ing.IntersectWith(ingrediends[indexes[i]]);
                }
                blocked.Add(all, ing);
                for (var i = 0; i < ingrediends.Count; i++)
                {
                    allergens[i].Remove(all);
                }
            }

            return blocked;
        }
    }
}


