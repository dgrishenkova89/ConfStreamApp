using ConfStream.Common.Enums;
using ConfStream.Database.Common.Abstractions;
using ConfStream.Database.Common.Extensions;
using ConfStream.Database.Common.Models;
using ConfStream.Database.Common.Specifications.BaseSpecifications;
using ConfStream.Database.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ConfStream.Database
{
    public class DatabaseRepository : IRepository<DatabaseContext>
    {
        public DatabaseContext Context { get; }

        protected virtual IQueryable<TEntity> Set<TEntity>()
            where TEntity : BaseEntity
                => Context.Set<TEntity>();

        protected DatabaseRepository(DatabaseContext context)
        {
            Context = context;
        }

        public async Task<long> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : BaseEntity
        {
            var entry = Context.Add(entity);

            await Context.SaveChangesAsync(cancellationToken);

            return entry.Entity.Id;
        }

        public Task<bool> AnyAsync<TEntity>(Specification<TEntity> specification, CancellationToken cancellationToken, IEnumerable<string> includedProperties = null, bool noTracking = true, bool asSplitQuery = false) where TEntity : BaseEntity
        {
            var query = Set<TEntity>().IncludeAll(includedProperties);

            if (asSplitQuery)
            {
                query = query.AsSplitQuery();
            }

            return query.AnyAsync(specification.Expression, cancellationToken);
        }

        public async Task DeleteAsync<TEntity>(Specification<TEntity> specification, CancellationToken cancellationToken) where TEntity : BaseEntity
        {
            var entity = await Set<TEntity>().FirstOrDefaultAsync(specification.Expression, cancellationToken) ??
                throw new InvalidOperationException(
                    $"Could not find entity {typeof(TEntity).Name} by specification {specification.GetType().Name}");

            Context.Remove(entity);

            await Context.SaveChangesAsync(cancellationToken);
        }

        public Task<TProjection> FirstOrDefaultAsync<TEntity, TProjection>(Specification<TEntity> specification, Expression<Func<TEntity, TProjection>> projectExpression, CancellationToken cancellationToken, IEnumerable<string> includedProperties = null, bool noTracking = true, bool asSplitQuery = true, IEnumerable<Expression<Func<TEntity, object>>> sortingExpressions = null, SortingOrder? sortingOrder = null) where TEntity : BaseEntity
        {
            var query = Set<TEntity>().GetFilteredQueryWithSorting(
                specification, projectExpression, includedProperties, noTracking, asSplitQuery, sortingExpressions: sortingExpressions, sortingOrder: sortingOrder);

            return query.FirstOrDefaultAsync(cancellationToken);
        }

        public Task<TProjection[]> GetArrayAsync<TEntity, TProjection>(Specification<TEntity> specification, Expression<Func<TEntity, TProjection>> projectExpression, CancellationToken cancellationToken, IEnumerable<string> includedProperties = null, bool noTracking = true, int skip = 0, int take = 0, IEnumerable<Expression<Func<TEntity, object>>> sortingExpressions = null, SortingOrder? sortingOrder = null, bool asSplitQuery = false, bool useDistinct = false) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync<TEntity>(Specification<TEntity> specification, Action<TEntity> updateAction, CancellationToken cancellationToken, IEnumerable<string> includedProperties = null) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }
    }
}
