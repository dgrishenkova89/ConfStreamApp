using ConfStream.Common.Enums;
using ConfStream.Database.Common.Models;
using ConfStream.Database.Common.Specifications.BaseSpecifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ConfStream.Database.Common.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TProjection> GetFilteredQueryWithSorting<TEntity, TProjection>(
            this IQueryable<TEntity> query,
            Specification<TEntity> specification,
            Expression<Func<TEntity, TProjection>> projectExpression,
            IEnumerable<string> includedProperties,
            bool noTracking,
            bool asSplitQuery,
            int skip = default,
            int take = default,
            IEnumerable<Expression<Func<TEntity, object>>> sortingExpressions = null,
            SortingOrder? sortingOrder = null)
            where TEntity : BaseEntity
        {
            query = query.GetFilteredQuery(specification, includedProperties, noTracking, asSplitQuery);

            if (sortingExpressions != null)
            {
                query = query.ApplySorting(sortingExpressions, sortingOrder);
            }

            if (skip != default)
            {
                query = query.Skip(skip);
            }

            if (take != default)
            {
                query = query.Take(take);
            }

            return query.Select(projectExpression);
        }

        public static IQueryable<TEntity> GetFilteredQuery<TEntity>(
            this IQueryable<TEntity> query,
            Specification<TEntity> specification,
            IEnumerable<string> includedProperties,
            bool noTracking,
            bool asSplitQuery)
            where TEntity : BaseEntity
        {
            query = query.IncludeAll(includedProperties);

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            if (asSplitQuery)
            {
                query = query.AsSplitQuery();
            }

            query = query.DefaultIfEmpty();
            query = query.Where(specification.Expression);

            return query;
        }

        public static IQueryable<TEntity> IncludeAll<TEntity>(this IQueryable<TEntity> query, IEnumerable<string> includedProperties = null)
            where TEntity : BaseEntity
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var includedPropertiesArray = includedProperties?.ToArray();

            if (includedPropertiesArray == null || !includedPropertiesArray.Any())
            {
                return query;
            }

            foreach (var property in includedPropertiesArray)
            {
                query = query.Include(property);
            }

            return query;
        }

        private static IQueryable<TEntity> ApplySorting<TEntity>(
            this IQueryable<TEntity> query,
            IEnumerable<Expression<Func<TEntity, object>>> sortingExpressions,
            SortingOrder? sortingOrder)
            where TEntity : BaseEntity
        {
            sortingOrder ??= SortingOrder.Asc;

            var i = 0;

            foreach (var sortingExpression in sortingExpressions)
            {
                if (i == 0)
                {
                    query = sortingOrder == SortingOrder.Asc
                        ? query.OrderBy(sortingExpression)
                        : query.OrderByDescending(sortingExpression);
                }
                else
                {
                    var orderedQuery = (IOrderedQueryable<TEntity>)query;

                    query = sortingOrder == SortingOrder.Asc
                        ? orderedQuery.ThenBy(sortingExpression)
                        : orderedQuery.ThenByDescending(sortingExpression);
                }

                i++;
            }

            return query;
        }
    }
}
