using Plastiline.Core.Extensions;
using Xunit;

namespace Plastiline.Tests.Extensions
{
    public class StringExtensionTest
    {
        [Fact]
        public void CapFirstNullStringResultsInNullString()
        {
            string input = null;
            Assert.Null(input.CapFirst());
        }

        [Fact]
        public void CapFirstEmptyStringResultsInEmptyString()
        {
            string input = "";
            Assert.Equal("", input.CapFirst());
        }

        [Fact]
        public void CapFirstNotEmptyString()
        {
            string input = "csharp";
            Assert.Equal("Csharp", input.CapFirst());
        }

        [Fact]
        public void UncapFirstNullStringResultsInNullString()
        {
            string input = null;
            Assert.Null(input.UncapFirst());
        }

        [Fact]
        public void UncapFirstEmptyStringResultsInEmptyString()
        {
            string input = "";
            Assert.Equal("", input.UncapFirst());
        }

        [Fact]
        public void UncapFirstNotEmptyString()
        {
            string input = "CSharp";
            Assert.Equal("cSharp", input.UncapFirst());
        }
    }
}
