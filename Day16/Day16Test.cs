using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day16
{
    public class Day16Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day16Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(0, Day16.Star1(lines));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day16Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(0, Day16.Star1(lines));
        }
    }
}