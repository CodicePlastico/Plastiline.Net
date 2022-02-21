namespace Plastiline.Core.Extensions
{
    public static class IListExtension
    {
        private static readonly Random Randomizer = new();

        public static T? Random<T>(this IList<T>? list)
        {
            if (list == null || list.Count == 0)
            {
                return default;
            }
            return list.ElementAt(Randomizer.Next(list.Count));
        }
    }
}
