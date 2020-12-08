using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day5
{
    public class Day5Test
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(357, Day5.Star1("FBFBBFFRLR"));
            Assert.Equal(567, Day5.Star1("BFFFBBFRRR"));
            Assert.Equal(119, Day5.Star1("FFFBBBFRRR"));
            Assert.Equal(820, Day5.Star1("BBFFBBFRLL"));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day5Part1Input.txt").ConfigureAwait(false);
            var seats = lines.Select(e => Day5.Star1(e)).OrderBy(e => e).ToArray();
            for (int i = 1; i < seats.Length; i++)
            {
                if (seats[i - 1] + 2 == seats[i])
                {
                    Assert.Equal(623, seats[i] - 1);
                    return;
                }
            }
            Assert.False(true);
        }
    }
}