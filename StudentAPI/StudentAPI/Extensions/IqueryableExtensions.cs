﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StudentAPI.Extensions
{
    public static class IqueryableExtensions
    {
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnMap)
        {

            if (String.IsNullOrWhiteSpace(queryObj.SortBy) || !columnMap.ContainsKey(queryObj.SortBy))
                return query;


            if (queryObj.IsAsc)
                return query.OrderBy(columnMap[queryObj.SortBy]);
            else
                return query.OrderByDescending(columnMap[queryObj.SortBy]);

        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if (queryObj.Page <= 0)
                queryObj.Page = 1;

            if (queryObj.PageSize <= 0)
                queryObj.PageSize = 10;

            return query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
        }

    }
}
