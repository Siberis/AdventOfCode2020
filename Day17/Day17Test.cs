using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day17
{
    public class Day17Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day17Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(112, Day17.Star1(lines));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day17Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(375, Day17.Star1(lines));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day17Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(848, Day17.Star1(lines, true));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day17Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(2192, Day17.Star1(lines, true));
        }
    }
}