using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using webapi.core.Modelos;

namespace webapi.business.Servicios
{
    public interface IArticulosVariosServicio
    {
        Task<IEnumerable<ArticulosVarios>> ListarTodos();
        Task<IEnumerable<ArticulosVarios>> ObtenerPorPatente(string pPatente);
        Task<IEnumerable<ArticulosVarios>> ObtenerPorLegajo(int pNroLegajo);
    }
}
