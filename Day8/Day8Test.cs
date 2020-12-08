using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day8
{
    public class Day8Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day8Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(5, Day8.Star1(lines));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day8Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(2058, Day8.Star1(lines));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day8Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(8, Day8.Star2(lines));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day8Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(1000, Day8.Star2(lines));
        }
    }
}