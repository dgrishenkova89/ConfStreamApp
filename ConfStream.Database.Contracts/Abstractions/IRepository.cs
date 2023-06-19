using ConfStream.Common.Enums;
using ConfStream.Database.Common.Models;
using ConfStream.Database.Common.Specifications.BaseSpecifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ConfStream.Database.Common.Abstractions
{
    public interface IRepository<out TDbContext>
        where TDbContext : DbContext
    {
        TDbContext Context { get; }

        Task<long> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
            where TEntity : BaseEntity;

        Task<bool> AnyAsync<TEntity>(
                Specification<TEntity> specification,
                CancellationToken cancellationToken,
                IEnumerable<string> includedProperties = null,
                bool noTracking = true,
                bool asSplitQuery = false)
            where TEntity : BaseEntity;

        Task DeleteAsync<TEntity>(Specification<TEntity> specification, CancellationToken cancellationToken)
            where TEntity : BaseEntity;

        Task<TProjection> FirstOrDefaultAsync<TEntity, TProjection>(
                Specification<TEntity> specification,
                Expression<Func<TEntity, TProjection>> projectExpression,
                CancellationToken cancellationToken,
                IEnumerable<string> includedProperties = null,
                bool noTracking = true,
                bool asSplitQuery = true,
                IEnumerable<Expression<Func<TEntity, object>>> sortingExpressions = null,
                SortingOrder? sortingOrder = null)
            where TEntity : BaseEntity;

        Task<TProjection[]> GetArrayAsync<TEntity, TProjection>(
                Specification<TEntity> specification,
                Expression<Func<TEntity, TProjection>> projectExpression,
                CancellationToken cancellationToken,
                IEnumerable<string> includedProperties = null,
                bool noTracking = true,
                int skip = default,
                int take = default,
                IEnumerable<Expression<Func<TEntity, object>>> sortingExpressions = null,
                SortingOrder? sortingOrder = null,
                bool asSplitQuery = false,
                bool useDistinct = false)
            where TEntity : BaseEntity;

        Task UpdateAsync<TEntity>(
                Specification<TEntity> specification,
                Action<TEntity> updateAction,
                CancellationToken cancellationToken,
                IEnumerable<string> includedProperties = null)
            where TEntity : BaseEntity;
    }
}
