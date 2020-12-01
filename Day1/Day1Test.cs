using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day1
{
    public class Day1Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day1Part1.txt");
            var numbers = lines.Select(e => int.Parse(e)).ToArray();

            Assert.Equal(514579, Day1.Star1(numbers));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day1Part1Input.txt");
            var numbers = lines.Select(e => int.Parse(e)).ToArray();

            Assert.Equal(1020084, Day1.Star1(numbers));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day1Part1.txt");
            var numbers = lines.Select(e => int.Parse(e)).ToArray();

            Assert.Equal(241861950, Day1.Star2(numbers));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day1Part1Input.txt");
            var numbers = lines.Select(e => int.Parse(e)).ToArray();

            Assert.Equal(295086480, Day1.Star2(numbers));
        }
    }
}
