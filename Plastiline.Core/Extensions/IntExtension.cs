namespace Plastiline.Core.Extensions
{
    public static class IntExtension
    {
        public static void Times(this int n, Action<int> action)
        {
            for (var i = 1; i <= n; i++)
            {
                action(i);
            }
        }
    }
}
