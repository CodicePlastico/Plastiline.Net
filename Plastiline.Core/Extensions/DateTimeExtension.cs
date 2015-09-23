using System;

namespace Plastiline.Core.Extensions
{
    public static class DateTimeExtension
    {
        public static long Epoch(this DateTime date)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalMilliseconds);
        }
    }
}
