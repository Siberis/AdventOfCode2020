using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day6
{
    public class Day6Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day6Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(11, Day6.Star1(lines));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day6Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(6551, Day6.Star1(lines));
        }

        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day6Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(6, Day6.Star2(lines));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day6Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(3358, Day6.Star2(lines));
        }

    }
}