using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Day20
{
    public static class Day20
    {
        public static decimal Star1(string[] lines)
        {
            var tiles = new Dictionary<decimal, List<string>>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Trim().Length == 0)
                {
                    continue;
                }
                var id = decimal.Parse(lines[i].Split(" ")[1][..^1]);
                i++;
                var tile = new List<string>();
                while (i < lines.Length && lines[i].Trim().Length != 0)
                {
                    tile.Add(lines[i]);
                    i++;
                }
                tiles.Add(id, tile);
            }
            var found = new Dictionary<decimal, Dictionary<decimal, List<string>>>();
            var keys = tiles.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                for (int j = i; j < keys.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    var ix = keys[i];
                    var jx = keys[j];
                    var combX = new HashSet<string>{
                        string.Concat(tiles[ix][0]),
                        string.Concat(tiles[ix][^1]),
                        string.Join("", tiles[ix].Select(e => e[0])),
                        string.Join("", tiles[ix].Select(e => e[^1])),
                        string.Join("", tiles[ix][0].Reverse()),
                        string.Join("", tiles[ix][^1].Reverse()),
                        string.Join("", tiles[ix].Select(e => e[0]).Reverse()),
                        string.Join("", tiles[ix].Select(e => e[^1]).Reverse())
                    };
                    var combY = new HashSet<string>{
                        string.Concat(tiles[jx][0]),
                        string.Concat(tiles[jx][^1]),
                        string.Join("", tiles[jx].Select(e => e[0])),
                        string.Join("", tiles[jx].Select(e => e[^1])),
                        string.Join("", tiles[jx][0].Reverse()),
                        string.Join("", tiles[jx][^1].Reverse()),
                        string.Join("", tiles[jx].Select(e => e[0]).Reverse()),
                        string.Join("", tiles[jx].Select(e => e[^1]).Reverse())
                    };
                    if (combX.Intersect(combY).Any())
                    {
                        if (!found.ContainsKey(ix)) found.Add(ix, new Dictionary<decimal, List<string>>());
                        if (!found.ContainsKey(jx)) found.Add(jx, new Dictionary<decimal, List<string>>());
                        found[ix].Add(jx, tiles[jx]);
                        found[jx].Add(ix, tiles[ix]);
                    }
                }
            }
            var corners = found.Where(e => e.Value.Count == 2).Select(e => e.Key).ToArray();
            return corners[0] * corners[1] * corners[2] * corners[3];
        }
    }
}


