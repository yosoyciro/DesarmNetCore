using System;
using System.Collections.Generic;
using System.Text;
using webapi.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using webapi.Core.Specs;
using webapi.core.Specs;

namespace webapi.data.Repositorios.Implementaciones
{
    public class Repositorio<T> : IRepositorio<T> where T : BaseEntity
    {
        protected readonly DesarmDatacenterContext context;
        //private DbSet<T> entities;
        //string errorMessage = string.Empty;
        public Repositorio(DesarmDatacenterContext context)
        {
            this.context = context;
            //entities = context.Set<T>();
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task AgregarAsync(T Entity)
        {
            await context.Set<T>().AddAsync(Entity);
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecs(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> GetByIdWithSpecs(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(context.Set<T>().AsQueryable(), spec);
        }        
    }
}
