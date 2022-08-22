using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.core.Modelos;
using webapi.root;
using webapi.data.Repositorios;
using AutoMapper;
using webapi.api.Recursos;

namespace webapi.api.Controllers
{
    [Route("api/ArticulosStock")]
    [ApiController]
    public class ArticulosStockController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public ArticulosStockController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("ListarTodos")]
        public async Task<IEnumerable<ArticulosStock>> ListarTodos() => await unitOfWork.ArticulosStockRepositorio.GetAll();

        [HttpGet("ObtenerPorVehiculo")]
        public async Task<ActionResult<IEnumerable<ArticulosStockRecurso>>> ObtenerPorVehiculo(int pVehiculosId)
        {
            var articulosStock = await unitOfWork.ArticulosStockRepositorio.ObtenerPorVehiculo(pVehiculosId);
            var articulosStockRecurso = _mapper.Map<IEnumerable<ArticulosStock>, IEnumerable<ArticulosStockRecurso>>(articulosStock);

            return Ok(articulosStockRecurso);
        }

        [HttpGet("ObtenerPorFormulario04D")]
        public async Task<ActionResult<IEnumerable<ArticulosStockRecurso>>> ObtenerPorFormulario04D(int pFormularios04DId   )
        {
            var articulosStock = await unitOfWork.ArticulosStockRepositorio.ObtenerPorFormulario04D(pFormularios04DId);
            var articulosStockRecurso = _mapper.Map<IEnumerable<ArticulosStock>, IEnumerable<ArticulosStockRecurso>>(articulosStock);

            return Ok(articulosStockRecurso);
        }
    }
}
