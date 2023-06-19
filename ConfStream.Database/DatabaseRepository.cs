using ConfStream.Common.Enums;
using ConfStream.Database.Common.Abstractions;
using ConfStream.Database.Common.Models;
using ConfStream.Database.Common.Specifications.BaseSpecifications;
using ConfStream.Database.EF;
using System.Linq.Expressions;

namespace ConfStream.Database
{
    public class DatabaseRepository : IRepository<DatabaseContext>
    {
        public DatabaseContext Context => throw new NotImplementedException();

        public Task<long> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync<TEntity>(Specification<TEntity> specification, CancellationToken cancellationToken, IEnumerable<string> includedProperties = null, bool noTracking = true, bool asSplitQuery = false) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync<TEntity>(Specification<TEntity> specification, CancellationToken cancellationToken) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public Task<TProjection> FirstOrDefaultAsync<TEntity, TProjection>(Specification<TEntity> specification, Expression<Func<TEntity, TProjection>> projectExpression, CancellationToken cancellationToken, IEnumerable<string> includedProperties = null, bool noTracking = true, bool asSplitQuery = true, IEnumerable<Expression<Func<TEntity, object>>> sortingExpressions = null, SortingOrder? sortingOrder = null) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
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
