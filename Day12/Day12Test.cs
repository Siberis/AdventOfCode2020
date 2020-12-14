using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day12
{
    public class Day12Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day12Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(25, Day12.Star1(lines));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day12Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(1032, Day12.Star1(lines));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day12Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(286, Day12.Star2(lines));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day12Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(156735, Day12.Star2(lines));
        }
    }
}