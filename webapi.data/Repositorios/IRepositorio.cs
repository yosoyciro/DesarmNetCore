using System;
using System.Collections.Generic;
using System.Text;
using webapi.core.Modelos;
using System.Threading.Tasks;
using System.Linq.Expressions;
using webapi.Core.Specs;

namespace webapi.data.Repositorios
{
    public interface IRepositorio<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T> GetById(int id);        
        Task<IReadOnlyList<T>> GetAllWithSpecs(ISpecification<T> spec);
        Task<T> GetByIdWithSpecs(ISpecification<T> spec);
        Task AgregarAsync(T Entity);

    }
}
