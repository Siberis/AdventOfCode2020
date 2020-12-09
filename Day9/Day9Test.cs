using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day9
{
    public class Day9Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day9Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(127, Day9.Star1(lines.Select(e => decimal.Parse(e)).ToArray(), 5));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day9Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(731031916, Day9.Star1(lines.Select(e => decimal.Parse(e)).ToArray(), 25));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day9Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(62, Day9.Star2(lines.Select(e => decimal.Parse(e)).ToArray(), 5));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day9Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(93396727, Day9.Star2(lines.Select(e => decimal.Parse(e)).ToArray(), 25));
        }
    }
}