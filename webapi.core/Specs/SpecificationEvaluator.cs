using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.core.Modelos;
using webapi.Core.Specs;

namespace webapi.core.Specs
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            if(spec.Criteria != null)
            {
                inputQuery = inputQuery.Where(spec.Criteria);
            }

            if(spec.Order != null)
            {
                bool isOrdered = false;
                foreach (ISpecification<T>.OrderDetails order in spec.Order)
                {
                    if (isOrdered)
                    {
                        IOrderedQueryable<T> ordered = inputQuery as IOrderedQueryable<T>;
                        inputQuery = (order.Descending) ? ordered.ThenByDescending(order.By) : ordered.ThenBy(order.By);
                    }
                    else
                    {
                        inputQuery = (order.Descending) ? inputQuery.OrderByDescending(order.By) : inputQuery.OrderBy(order.By);
                        isOrdered = true;
                    }
                }
            }

            if (spec.Pagination != null)
            {
                inputQuery = inputQuery.Skip(spec.Pagination.Skip).Take(spec.Pagination.Take);
            }
            
            inputQuery = spec.Includes.Aggregate(inputQuery, (current, include) => current.Include(include));

            return inputQuery;
        }
    }
}
