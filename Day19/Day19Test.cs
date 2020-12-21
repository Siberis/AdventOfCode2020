using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day19
{
    public class Day19Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day19Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(2, Day19.Star1(lines));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day19Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(250, Day19.Star1(lines));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day19Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(2, Day19.Star2(lines));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day19Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(359, Day19.Star2(lines));
        }

    }
}