using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day11
{
    public class Day11Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day11Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(37, Day11.Star1(lines, 4, 1));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day11Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(2263, Day11.Star1(lines, 4, 1));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day11Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(26, Day11.Star1(lines, 5, 8));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day11Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(2002, Day11.Star1(lines, 5, 100));
        }
    }
}