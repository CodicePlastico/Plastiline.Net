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
        [Fact]
        public void EpochFor19700101OnUtcIs0()
        {
            DateTime startOfEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            Assert.Equal(0, startOfEpoch.Epoch());
        }

        [Fact]
        public void EpochFor19700102OnUtcIs86400000()
        {
            DateTime startOfEpoch = new DateTime(1970, 1, 2, 0, 0, 0, DateTimeKind.Utc);
            Assert.Equal(86400000, startOfEpoch.Epoch());
        }

        [Fact]
        public void EpochFor19700101OnLocalTimeZoneIs0()
        {
            DateTime startOfEpoch = new DateTime(1969, 12, 31, 23, 0, 0, DateTimeKind.Utc);
            TimeZoneInfo info = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            DateTime centralEurope = TimeZoneInfo.ConvertTime(startOfEpoch, info);
            Assert.Equal(-3600000, centralEurope.Epoch());
        }
    }
}
