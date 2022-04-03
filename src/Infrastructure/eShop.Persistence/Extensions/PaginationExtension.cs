namespace eShop.Persistence.Extensions;

public static class PaginationExtension
{
    public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, int page, int size)
        => query.Skip((page - 1) * size).Take(size);
}
