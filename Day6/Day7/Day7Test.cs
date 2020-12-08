using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day7
{
    public class Day7Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day7Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(4, Day7.Star1(lines));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day7Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(242, Day7.Star1(lines));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day7Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(32, Day7.Star2(lines));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day7Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(176035, Day7.Star2(lines));
        }
    }
}