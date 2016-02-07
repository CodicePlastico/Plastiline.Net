using System.Dynamic;
using Plastiline.Core.Mapping;
using Xunit;

namespace Plastiline.Core.Tests.Mapping
{
    public class DynamicMapperTest
    {
        private const short ShortVal = 19;

        [Fact]
        public void MapDynamicToShort()
        {
            dynamic input = new ExpandoObject();
            input.value = ShortVal.ToString();
            Assert.Equal(ShortVal, DynamicMapper.ToShort(input.value));
        }

        [Fact]
        public void MapNullDynamicToShort()
        {
            dynamic input = new ExpandoObject();
            input.value = null;
            Assert.Equal(null, DynamicMapper.ToShort(input.value));
        }
    }
}
