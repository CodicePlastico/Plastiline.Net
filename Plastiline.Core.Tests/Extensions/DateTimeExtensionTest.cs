using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plastiline.Core.Extensions;
using Xunit;

namespace Plastiline.Core.Tests.Extensions
{
    public class DateTimeExtensionTest
    {
        private static readonly DateTime StartOfEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        [Fact]
        public void EpochFor19700101OnUtcIs0()
        {
            Assert.Equal(0, StartOfEpoch.Epoch());
        }

        [Fact]
        public void EpochFor19700102OnUtcIs86400000()
        {
            DateTime aDayLater = new DateTime(1970, 1, 2, 0, 0, 0, DateTimeKind.Utc);
            Assert.Equal(86400000, aDayLater.Epoch());
        }

        [Fact]
        public void EpochFor19700101OnLocalTimeZoneIs0()
        {
            DateTime oneHourAgo = new DateTime(1969, 12, 31, 23, 0, 0, DateTimeKind.Utc);
            TimeZoneInfo info = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            DateTime centralEurope = TimeZoneInfo.ConvertTime(oneHourAgo, info);
            Assert.Equal(-3600000, centralEurope.Epoch());
        }

        [Fact]
        public void ZeroIsEpochSource()
        {
            Assert.Equal(StartOfEpoch, ((long)0).ToDateTime());
        }

        [Fact]
        public void LongValueIsEpochOffset()
        {
            DateTime oneHourAgo = new DateTime(1969, 12, 31, 23, 0, 0, DateTimeKind.Utc);
            Assert.Equal(oneHourAgo, ((long)-3600000).ToDateTime());
        }
    }
}
