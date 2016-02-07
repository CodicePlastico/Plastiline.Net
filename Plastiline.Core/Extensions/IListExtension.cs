using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plastiline.Core.Extensions
{
    public static class IListExtension
    {
        private static readonly Random Randomizer = new Random();

        public static T Random<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return default(T);
            }
            return list.ElementAt(Randomizer.Next(list.Count()));
        }
    }
}
