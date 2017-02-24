using RestResource.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestResource.Rest
{
    public static class Extensions
    {

        public static string GetUrl(this Pagination pagination)
        {
            return $"page={(pagination?.Page) ?? 0}&limit={(pagination?.Limit) ?? 10}";
        }

        public static string GetUrl(this Sorting sorting)
        {
            if (sorting == null) return string.Empty;
            return sorting.OrderDirection == SortingDirection.DESC
                ? $"sort=-{sorting.OrderFieldName}"
                : $"sort={sorting.OrderFieldName}";
        }
    }
}
