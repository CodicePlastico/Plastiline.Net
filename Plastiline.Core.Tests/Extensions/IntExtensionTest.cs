using Plastiline.Core.Extensions;
using Xunit;

namespace Plastiline.Core.Tests.Extensions
{
    public class IntExtensionTest
    {
        [Fact]
        public void TestIteratingFromOneToNWithTimes()
        {
            string accumulator = "";
            int n = 5;
            n.Times( i => accumulator = accumulator + i.ToString());
            Assert.Equal("123456", accumulator);
        }

        [Fact]
        public void NoIterationWhenThisIsZero()
        {
            string accumulator = "";
            int n = 0;
            n.Times(i => accumulator = accumulator + i.ToString());
            Assert.Equal("", accumulator);
        }
    }
}
