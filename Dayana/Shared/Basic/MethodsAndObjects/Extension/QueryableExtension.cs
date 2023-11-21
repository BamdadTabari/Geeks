﻿namespace Dayana.Shared.Basic.MethodsAndObjects.Extension;

public static class QueryableExtension
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int pageSize) where T : class
    {
        return query.Skip((page - 1) * pageSize).Take(pageSize);
    }
}