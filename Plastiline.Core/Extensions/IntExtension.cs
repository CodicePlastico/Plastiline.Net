using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plastiline.Core.Extensions
{
    public static class IntExtension
    {
        public static void Times(this int n, Action<int> action)
        {
            for (int i = 1; i <= n; i++)
            {
                action(i);
            }
        }
    }
}
