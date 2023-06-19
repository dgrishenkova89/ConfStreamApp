using ConfStream.Database.Common.Extensions;
using ConfStream.Database.Common.Models;
using System.Linq.Expressions;

namespace ConfStream.Database.Common.Specifications.BaseSpecifications
{
    public class NotSpecification<T> : Specification<T>
        where T : BaseEntity
    {
        private readonly Specification<T> _spec1;

        public NotSpecification(Specification<T> spec1)
        {
            _spec1 = spec1;
        }

        public override Expression<Func<T, bool>> Expression => _spec1.Expression.Not();
    }
}
