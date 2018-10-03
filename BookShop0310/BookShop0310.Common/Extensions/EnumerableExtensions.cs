using System.Collections.Generic;

namespace BookShop0310.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable)
            => new HashSet<T>(enumerable);
    }
}