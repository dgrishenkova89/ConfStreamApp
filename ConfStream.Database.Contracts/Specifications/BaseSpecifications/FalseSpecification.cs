using ConfStream.Database.Common.Models;
using System.Linq.Expressions;

namespace ConfStream.Database.Common.Specifications.BaseSpecifications
{
    public class FalseSpecification<T> : Specification<T>
        where T : BaseEntity
    {
        public override Expression<Func<T, bool>> Expression => False();
    }
}
