namespace PetOwnerApplication.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class LinQUtility
    {
        public static IEnumerable<TResult> SelectManyExceptNull<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> handler)
        {
            return source.Select(handler)
                .Where(item => item != null)
                .SelectMany(item => item);
        }
    }
}
