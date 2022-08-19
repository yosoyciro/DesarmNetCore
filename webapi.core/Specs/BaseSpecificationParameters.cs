using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using webapi.core.Modelos;

namespace webapi.Core.Specs
{
    public class BaseSpecificationParameters<T> : ISpecificationParameters<T> where T : BaseEntity
    {
        private string _page;
        private string _sort;
        private int _pageIndex = 0;
        private int _pageSize = 0;
        private int _maxPageSize = 100;
        private ISpecification<T>.PaginationDetails _pagination;
        private ISet<ISpecification<T>.OrderDetails> _order;

        public string Page
        {
            get => _page;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _pagination = null;
                    _page = value;
                    return;
                }
                _page = value;

                List<string> vs = _page.Split(",").Where(s => int.TryParse(s, out _)).Take(2).ToList();

                int v;
                if (vs.Count > 0 && int.TryParse(vs[0], out v)) _pageIndex = v;
                if (vs.Count > 1 && int.TryParse(vs[1], out v)) _pageSize = v;

                if (_pageIndex < 1) _pageIndex = 1;
                if (_pageSize < 1) _pageSize = 1;
                else if (_pageSize > _maxPageSize) _pageSize = _maxPageSize;

                _pagination = new()
                {
                    Skip = _pageSize * (_pageIndex - 1),
                    Take = _pageSize
                };
            }
        }

        public string Sort
        {
            get => _sort;
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                _sort = value;
                // Armo la consulta de orden según parámetro
                _order = new HashSet<ISpecification<T>.OrderDetails>();
                _sort.Split(",").Where(s => !string.IsNullOrWhiteSpace(s)).ToList().ForEach(s => _order.Add(StringToOrderDetails(s)));
            }
        }

        public BaseSpecificationParameters()
        {
            //Page = string.Format("{0},{1}", _pageIndex, _pageSize);
        }

        public BaseSpecificationParameters(int maxPageSize) : this()
        {
            _maxPageSize = maxPageSize;
        }

        public int GetPageIndex() { return _pageIndex; }

        public int GetPageSize() { return _pageSize; }

        public ISpecification<T>.PaginationDetails GetPagination() { return _pagination; }

        public ISet<ISpecification<T>.OrderDetails> GetOrder() { return _order; }

        public virtual Expression<Func<T, bool>> GetCriteria() { return null; }

        public virtual ISpecification<T>.OrderDetails StringToOrderDetails(string str) { return new(); }
    }
}
