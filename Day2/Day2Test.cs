using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day2
{
    public class Day2Test
    {
        [Fact]
        public void Test1()
        {
            var lines = "1-3 a: abcde\n1-3 b: cdefg\n2-9 c: ccccccccc".Split("\n");
            Assert.Equal(2, Day2.Star1(lines));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day2Part1Input.txt").ConfigureAwait(false);

            Assert.Equal(591, Day2.Star1(lines));
        }
        [Fact]
        public void Test2()
        {
            var lines = "1-3 a: abcde\n1-3 b: cdefg\n2-9 c: ccccccccc".Split("\n");
            Assert.Equal(1, Day2.Star2(lines));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day2Part1Input.txt").ConfigureAwait(false);

            Assert.Equal(335, Day2.Star2(lines));
        }
    }
}