using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day3
{
    public class Day3Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day3Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(7, Day3.Star1(lines, 3, 1));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day3Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(225, Day3.Star1(lines, 3, 1));
        }

        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day3Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(336, Day3.Star1(lines, 1, 1) *
             Day3.Star1(lines, 3, 1) *
             Day3.Star1(lines, 5, 1) *
             Day3.Star1(lines, 7, 1) *
             Day3.Star1(lines, 1, 2));
        }

        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day3Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(1115775000, Day3.Star1(lines, 1, 1) *
             Day3.Star1(lines, 3, 1) *
             Day3.Star1(lines, 5, 1) *
             Day3.Star1(lines, 7, 1) *
             Day3.Star1(lines, 1, 2));
        }
    }
}