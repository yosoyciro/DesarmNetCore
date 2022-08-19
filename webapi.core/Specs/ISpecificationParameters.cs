using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using webapi.core.Modelos;

namespace webapi.Core.Specs
{
    public interface ISpecificationParameters<T> where T : BaseEntity
    {
        string Page { get; set; }

        string Sort { get; set; }

        int GetPageIndex();

        int GetPageSize();

        ISpecification<T>.PaginationDetails GetPagination();

        ISet<ISpecification<T>.OrderDetails> GetOrder();

        Expression<Func<T, bool>> GetCriteria() { return null; }

        ISpecification<T>.OrderDetails StringToOrderDetails(string str) { return new(); }

    }
}
