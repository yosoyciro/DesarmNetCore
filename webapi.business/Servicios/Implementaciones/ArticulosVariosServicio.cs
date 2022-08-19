using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using webapi.core.Modelos;
using webapi.data.Repositorios;
using webapi.data.Repositorios.Implementaciones;
using webapi.data;
using Microsoft.EntityFrameworkCore;

namespace webapi.business.Servicios.Implementaciones
{
    public class ArticulosVariosServicio : IArticulosVariosServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticulosVariosServicio(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ArticulosVarios>> ListarTodos()
        {
            return await _unitOfWork.ArticulosVariosRepositorio.GetAll();
        }

        public async Task<IEnumerable<ArticulosVarios>> ObtenerPorLegajo(int pNroLegajo)
        {
            return await _unitOfWork.ArticulosVariosRepositorio.ObtenerPorLegajo(pNroLegajo);
        }

        public async Task<IEnumerable<ArticulosVarios>> ObtenerPorPatente(string pPatente)
        {
            return await _unitOfWork.ArticulosVariosRepositorio.ObtenerPorPatente(pPatente);
        }
    }
}
