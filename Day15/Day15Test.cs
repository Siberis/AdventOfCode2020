using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day15
{
    public class Day15Test
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(436, Day15.Star1(new int[] { 0, 3, 6 }, 2020));
            Assert.Equal(27, Day15.Star1(new int[] { 1, 2, 3 }, 2020));
            Assert.Equal(10, Day15.Star1(new int[] { 2, 1, 3 }, 2020));
            Assert.Equal(1, Day15.Star1(new int[] { 1, 3, 2 }, 2020));
            Assert.Equal(78, Day15.Star1(new int[] { 2, 3, 1 }, 2020));
            Assert.Equal(438, Day15.Star1(new int[] { 3, 2, 1 }, 2020));
            Assert.Equal(1836, Day15.Star1(new int[] { 3, 1, 2 }, 2020));
        }
        [Fact]
        public void Star1()
        {
            Assert.Equal(1280, Day15.Star1(new int[] { 2, 15, 0, 9, 1, 20 }, 2020));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(175594, Day15.Star1(new int[] { 0, 3, 6 }, 30000000));
            Assert.Equal(261214, Day15.Star1(new int[] { 1, 2, 3 }, 30000000));
            Assert.Equal(3544142, Day15.Star1(new int[] { 2, 1, 3 }, 30000000));
            Assert.Equal(2578, Day15.Star1(new int[] { 1, 3, 2 }, 30000000));
            Assert.Equal(6895259, Day15.Star1(new int[] { 2, 3, 1 }, 30000000));
            Assert.Equal(18, Day15.Star1(new int[] { 3, 2, 1 }, 30000000));
            Assert.Equal(362, Day15.Star1(new int[] { 3, 1, 2 }, 30000000));
        }
        [Fact]
        public void Star2()
        {
            Assert.Equal(651639, Day15.Star1(new int[] { 2, 15, 0, 9, 1, 20 }, 30000000));
        }
    }
}