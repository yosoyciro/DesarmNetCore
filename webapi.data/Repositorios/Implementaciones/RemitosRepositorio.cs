using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using webapi.core.Modelos;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace webapi.data.Repositorios.Implementaciones
{
    public class RemitosRepositorio : Repositorio<Remitos>, IRemitosRepositorio
    {
        public RemitosRepositorio(DesarmDatacenterContext context) : base(context) { }

        private DesarmDatacenterContext DesarmDatacenterContext
        {
            get { return context as DesarmDatacenterContext; }
        }

        public async Task<Remitos> ObtenerPorIdConDetalle(int pRemitosId)
        {
            return await context.Remitos
                .Include(r => r.RemitosDetalles)
                    .ThenInclude(rd => rd.ArticulosStock)
                        .ThenInclude(a => a.Articulos)
                .Include(r => r.RemitosAuditorias)
                .SingleOrDefaultAsync(r => r.Id == pRemitosId);
        }

        public async Task<Remitos> ObtenerPorIdConDetalleYAuditoria(int pRemitosId)
        {
            return await context.Remitos
                .Include(r => r.RemitosDetalles)
                    .ThenInclude(rd => rd.ArticulosStock)
                        .ThenInclude(a => a.Articulos)
                .Include(r => r.RemitosAuditorias)                    
                .SingleOrDefaultAsync(r => r.Id == pRemitosId);
        }

        public async Task<IEnumerable<Remitos>> ObtenerPorFechas(int pFechaDesde, int pFechaHasta, string pTipo)
        {
            return await context.Remitos
                .Include(r => r.RemitosDetalles)
                    .ThenInclude(rd => rd.ArticulosStock)
                        .ThenInclude(a => a.Articulos)
                .Include(r => r.RemitosAuditorias)
                .Where(r => (r.FECHA >= pFechaDesde && r.FECHA <= pFechaHasta) && r.TIPO == pTipo)
                .ToListAsync();
        }

        public async Task Anular(Remitos pRemito)
        {
            pRemito.ESTADO = "A";
            await context.SaveChangesAsync();            
        }
    }
}
