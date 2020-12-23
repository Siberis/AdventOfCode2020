using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day23
{
    public class Day23Test
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal("67384529", Day23.Star1("389125467"));
        }
        [Fact]
        public void Star1()
        {
            Assert.Equal("28793654", Day23.Star1("871369452"));
        }
        [Fact]
        public void Test2()
        {
            Assert.Equal(359206768694, Day23.Star2("871369452"));
        }
    }
}