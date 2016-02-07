using System.Collections.Generic;
using Plastiline.Core.Extensions;
using Xunit;

namespace Plastiline.Core.Tests.Extensions
{
    public class IListExtensionTest
    {
        [Fact]
        public void GettingRandomItemFromNullListReturnsNull()
        {
            IList<string> list = null;
            Assert.Null(list.Random());
        }

        [Fact]
        public void GettingRandomItemFromEmptyListReturnsNull()
        {
            IList<string> list = new List<string>();
            Assert.Null(list.Random());
        }

        [Fact]
        public void GettingRandomItemFromListReturnsAnElementFromTheList()
        {
            IList<int> list = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            int rnd = list.Random();
            Assert.True(list.Contains(rnd));
        }

        [Fact]
        public void GettingRepeatedlyRandomItemFromListReturnsItemsWithUniformDistribution()
        {
            IList<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int count = 10000;
            IDictionary<int, int> extracted = new Dictionary<int, int>();
            foreach (int i in list)
            {
                extracted.Add(i, 0);
            }
            for (int i = 0; i < count; i++)
            {
                int rnd = list.Random();
                extracted[rnd] =extracted[rnd] + 1;
            }
            int perfectDistributionCount = count / list.Count;
            foreach (int i in extracted.Keys)
            {
                Assert.True(extracted[i] > 0.8 * perfectDistributionCount);
                Assert.True(extracted[i] < 1.2 * perfectDistributionCount);
            }
        }
    }
}
