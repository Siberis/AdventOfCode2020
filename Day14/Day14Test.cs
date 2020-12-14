using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day14
{
    public class Day14Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day14Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(165, Day14.Star1(lines));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day14Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(8332632930672, Day14.Star1(lines));
        }
        [Fact]
        public void Test2()
        {
            Assert.Equal(208, Day14.Star2(new string[]{
                "mask = 000000000000000000000000000000X1001X",
"mem[42] = 100",
"mask = 00000000000000000000000000000000X0XX",
"mem[26] = 1"
            }));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day14Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(4753238784664, Day14.Star2(lines));
        }
    }
}