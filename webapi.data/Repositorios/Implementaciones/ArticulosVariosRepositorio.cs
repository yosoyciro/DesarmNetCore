using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using webapi.core.Modelos;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace webapi.data.Repositorios.Implementaciones
{
    public class ArticulosVariosRepositorio : Repositorio<ArticulosVarios>, IArticulosVariosRepositorio
    {
        public ArticulosVariosRepositorio(DesarmDatacenterContext context) : base(context) { }

        private DesarmDatacenterContext DesarmDatacenterContext
        {
            get { return context as DesarmDatacenterContext; }
        }

        public async Task<IEnumerable<ArticulosVarios>> ObtenerPorLegajo(int pNroLegajo)
        {
            return await context.ArticulosVarios
                .Include(av => av.Articulos)
                .Include(av => av.Vehiculos)
                    .ThenInclude(v => v.Formulario04D)
                .Where(a => a.Vehiculos.Formulario04D.NROLEGAJO == pNroLegajo)
                .ToListAsync();
        }

        public async Task<IEnumerable<ArticulosVarios>> ObtenerPorPatente(string pPatente)
        {
            return await context.ArticulosVarios
                .Include(av => av.Articulos)
                .Include(av => av.Vehiculos).ThenInclude(v => v.VehiculosTipo)
                .Include(av => av.Vehiculos).ThenInclude(v => v.Formulario04D)
                .Where(a => a.Vehiculos.Patente == pPatente)
                .ToListAsync();
        }      
    }
}
