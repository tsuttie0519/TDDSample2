using System;
using Xunit;

namespace TDDSample2.Web.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(1,1);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(2.0m , Math.Round(1.5m));
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(2.0m, Math.Round(2.5m));
        }
    }
}
