using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using webapi.core.Modelos;

namespace webapi.Core.Specs
{ 
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public BaseSpecification() { }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        
        public BaseSpecification(BaseSpecificationParameters<T> parameters)
        {
            Pagination = parameters.GetPagination();
            Order = parameters.GetOrder();
            Criteria = parameters.GetCriteria();
        }

        public Expression<Func<T, bool>> Criteria { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();

        public ISet<ISpecification<T>.OrderDetails> Order { get; set; }

        public ISpecification<T>.PaginationDetails Pagination { get; set; }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

    }
}
