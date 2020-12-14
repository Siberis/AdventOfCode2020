using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day13
{
    public class Day13Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day13Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(295, Day13.Star1(lines));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day13Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(246, Day13.Star1(lines));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day13Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(754018, Day13.Star2(new string[] { "1", "67,7,59,61" }));
            Assert.Equal(779210, Day13.Star2(new string[] { "1", "67,x,7,59,61" }));
            Assert.Equal(1261476, Day13.Star2(new string[] { "1", "67,7,x,59,61" }));
            Assert.Equal(1202161486, Day13.Star2(new string[] { "1", "1789,37,47,1889" }));
            Assert.Equal(1068781, Day13.Star2(lines));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day13Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(939490236001473, Day13.Star2(lines));
        }
    }
}