using System;
using System.Collections.Generic;
using System.Text;
using webapi.core.Modelos;
using System.Threading.Tasks;

namespace webapi.data.Repositorios
{
    public interface IArticulosVariosRepositorio : IRepositorio<ArticulosVarios>
    {
        Task<IEnumerable<ArticulosVarios>> ObtenerPorPatente(string pPatente);
        Task<IEnumerable<ArticulosVarios>> ObtenerPorLegajo(int pNroLegajo);
    }
}
