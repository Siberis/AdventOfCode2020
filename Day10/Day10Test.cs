using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day10
{
    public class Day10Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day10Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(35, Day10.Star1(lines.Select(e => int.Parse(e)).ToArray()));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day10Part1Test2.txt").ConfigureAwait(false);
            Assert.Equal(220, Day10.Star1(lines.Select(e => int.Parse(e)).ToArray()));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day10Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(2112, Day10.Star1(lines.Select(e => int.Parse(e)).ToArray()));
        }
        [Fact]
        public async Task Test3()
        {
            var lines = await ReadUtils.ReadAllLines("./Day10Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(8, Day10.Star2(lines.Select(e => int.Parse(e)).ToArray()));
        }
        [Fact]
        public async Task Test4()
        {
            var lines = await ReadUtils.ReadAllLines("./Day10Part1Test2.txt").ConfigureAwait(false);
            Assert.Equal(19208, Day10.Star2(lines.Select(e => int.Parse(e)).ToArray()));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day10Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(3022415986688, Day10.Star2(lines.Select(e => int.Parse(e)).ToArray()));
        }
    }
}