namespace Message.ExtensionMethods
{
    public static class PaginationExtensionMethod
    {
        public static IEnumerable<T> ToPagedList<T>(this IEnumerable<T> queryable, int pageNumber, int pageSize)
        {
            return queryable.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
