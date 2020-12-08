using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day8
{
    public static class Day8
    {
        public static int Star1(string[] instructions)
        {
            var visited = new HashSet<int>();
            var inst = instructions.Select((e) =>
            {
                var args = e.Split(" ");
                return (args[0], int.Parse(args[1]));
            }).ToArray();
            var acc = 0;
            var pos = 0;
            while (!visited.Contains(pos))
            {
                visited.Add(pos);
                var (ins, arg) = inst[pos];
                if (ins == "nop")
                {
                    pos++;
                }
                else if (ins == "acc")
                {
                    acc += arg;
                    pos++;
                }
                else if (ins == "jmp")
                {
                    pos += arg;
                }
            }
            return acc;
        }
        public static int Star2(string[] instructions)
        {
            var inst = instructions.Select((e) =>
            {
                var args = e.Split(" ");
                return (args[0], int.Parse(args[1]));
            }).ToArray();
            for (int i = 0; i < inst.Length; ++i)
            {
                if (inst[i].Item1 == "jmp")
                {
                    inst[i].Item1 = "nop";
                    var (res, pos) = CheckLoop(inst);
                    if (pos == inst.Length)
                    {
                        return res;
                    }
                    inst[i].Item1 = "jmp";
                }
            }
            return 0;
        }

        private static (int, int) CheckLoop((string, int)[] inst)
        {
            var visited = new HashSet<int>();
            var acc = 0;
            var pos = 0;
            while (!visited.Contains(pos))
            {
                if (pos >= inst.Length)
                {
                    break;
                }
                visited.Add(pos);
                var (ins, arg) = inst[pos];
                if (ins == "nop")
                {
                    pos++;
                }
                else if (ins == "acc")
                {
                    acc += arg;
                    pos++;
                }
                else if (ins == "jmp")
                {
                    pos += arg;
                }
            }
            return (acc, pos);
        }
    }
}


