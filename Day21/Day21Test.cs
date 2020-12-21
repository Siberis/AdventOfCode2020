using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day21
{
    public class Day21Test
    {
        [Fact]
        public async Task Test1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day21Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal(5, Day21.Star1(lines));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day21Part1Input.txt").ConfigureAwait(false);
            Assert.Equal(1815, Day21.Star1(lines));
        }
        [Fact]
        public async Task Test2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day21Part1Test1.txt").ConfigureAwait(false);
            Assert.Equal("mxmxvkd,sqjhc,fvjkl", Day21.Star2(lines));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day21Part1Input.txt").ConfigureAwait(false);
            Assert.Equal("kllgt,jrnqx,ljvx,zxstb,gnbxs,mhtc,hfdxb,hbfnkq", Day21.Star2(lines));
        }
    }
}