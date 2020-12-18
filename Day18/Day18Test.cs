using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day18
{
    public class Day18Test
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(71, Day18.Star1(new string[] { "1 + 2 * 3 + 4 * 5 + 6" }));
            Assert.Equal(51, Day18.Star1(new string[] { "1 + (2 * 3) + (4 * (5 + 6))" }));
            Assert.Equal(26, Day18.Star1(new string[] { "2 * 3 + (4 * 5)" }));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day18Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(14006719520523, Day18.Star1(lines));
        }
        [Fact]
        public void Test2()
        {
            Assert.Equal(10521288, Day18.Star2(new string[] { "(7 * 6 * 3 + 4 * 3 * 9) + (6 * 6 * (4 + 6 + 4) + 7 + 2 + (9 * 8 * 9 + 9 * 7 * 4)) + (3 * 4 + 3 + 2) * 8" }));
            Assert.Equal(150273, Day18.Star2(new string[] { "7 + (2 + 8 * 8 * 2 + (4 * 3 * 9 + 4 * 4)) + 4 * 3" }));
            Assert.Equal(5269133408, Day18.Star2(new string[] { "8 + 9 * (2 + 2 * 5 + 9 * 2) * 2 + ((6 + 4) * 4 + (4 * 7 + 3 * 3 + 7) * (4 * 5 + 8 + 8 + 7 * 6) + (6 + 2) + 5)" }));
            Assert.Equal(23340, Day18.Star2(new string[] { "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2" }));
            Assert.Equal(669060, Day18.Star2(new string[] { "5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))" }));
            Assert.Equal(231, Day18.Star2(new string[] { "1 + 2 * 3 + 4 * 5 + 6" }));
            Assert.Equal(51, Day18.Star2(new string[] { "1 + (2 * 3) + (4 * (5 + 6))" }));
            Assert.Equal(46, Day18.Star2(new string[] { "2 * 3 + (4 * 5)" }));
            Assert.Equal(1445, Day18.Star2(new string[] { "5 + (8 * 3 + 9 + 3 * 4 * 3)" }));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day18Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(545115449981968, Day18.Star2(lines));
        }
    }
}