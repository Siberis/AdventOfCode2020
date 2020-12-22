using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day22
{
    public class Day22Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day22Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(306, Day22.Star1(lines));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day22Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(31455, Day22.Star1(lines));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day22Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(291, Day22.Star2(lines));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day22Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(32528, Day22.Star2(lines));
        }
    }
}