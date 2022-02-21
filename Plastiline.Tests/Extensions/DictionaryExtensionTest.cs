using System.Collections.Generic;
using Plastiline.Core.Extensions;
using Xunit;

namespace Plastiline.Tests.Extensions
{
    public class DictionaryExtensionTest
    {
        [Fact]
        public void GetValueOrDefault_EmptyDictionary_ReturnsDefault()
        {
            IDictionary<object, object> dict = new Dictionary<object, object>();
            object value = dict.GetValueOrDefault("key", "fallback");
            Assert.Equal("fallback", value);
        }

        [Fact]
        public void GetValueOrDefault_NonEmptyDictionaryWithKey_ReturnsValue()
        {
            IDictionary<object, object> dict = new Dictionary<object, object>
                {
                    { "key", "value" }
                };
            object value = dict.GetValueOrDefault("key", "fallback");
            Assert.Equal("value", value);
        }

        [Fact]
        public void GetValueOrDefault_NonEmptyDictionaryWithoutKey_ReturnsDefault()
        {
            IDictionary<object, object> dict = new Dictionary<object, object>
            {
                { "key", "value" }
            };
            object value = dict.GetValueOrDefault("anotherKey", "fallback");
            Assert.Equal("fallback", value);
        }
    }


}
