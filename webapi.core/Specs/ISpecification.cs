using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using webapi.core.Modelos;

namespace webapi.Core.Specs
{
    public interface ISpecification<T> where T : BaseEntity
    {
        /// <summary>
        /// Describe la información de paginado
        /// </summary>
        public class PaginationDetails
        {
            /// <summary>
            /// Cantidad de registros a adquirir
            /// </summary>
            public int Take { get; set; } = 100;

            /// <summary>
            /// Cantidad de registros a saltear
            /// </summary>
            public int Skip { get; set; } = 0;
        }
        
        /// <summary>
        /// Describe un ordenamiento de una lista por un campo
        /// </summary>
        public class OrderDetails
        {
            /// <summary>
            /// Si es orden descendente
            /// </summary>
            public bool Descending { get; set; } = false;

            /// <summary>
            /// Campo por el que ordenar
            /// </summary>
            public Expression<Func<T, object>> By { get; set; } = o => o.Id;
        }

        /// <summary>
        /// Condiciones logicas a aplicar (filtros, orden, busquedas)
        /// </summary>
        Expression<Func<T, bool>> Criteria { get; set; }

        /// <summary>
        /// Includes, relacion entre entidades
        /// </summary>
        List<Expression<Func<T, object>>> Includes { get; set; }

        /// <summary>
        /// Información de paginado, en caso de null, no paginar
        /// </summary>
        PaginationDetails Pagination { get; set; }
        
        /// <summary>
        /// Conjunto de campos por el que ordenar
        /// </summary>
        ISet<OrderDetails> Order { get; set; }
    }
}
