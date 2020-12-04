using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day4
{
    public class Day4Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day4Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(2, Day4.Star1(lines));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day4Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(208, Day4.Star1(lines));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day4Part2Test1.txt").ConfigureAwait(false);
            Assert.Equal(0, Day4.Star2(lines));
        }
        [Fact]
        public async Task Test3()
        {
            var lines = await ReadUtils.ReadAllLines("./Day4Part2Test2.txt").ConfigureAwait(false);
            Assert.Equal(4, Day4.Star2(lines));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day4Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(167, Day4.Star2(lines));
        }
    }
}