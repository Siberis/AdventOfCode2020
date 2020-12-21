using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day20
{
    public class Day20Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day20Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(20899048083289, Day20.Star1(lines));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day20Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(17032646100079, Day20.Star1(lines));
        }

    }
}