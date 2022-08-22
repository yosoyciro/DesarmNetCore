using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.core.Modelos;
using webapi.data.Repositorios;
using AutoMapper;
using webapi.api.Recursos;

namespace webapi.api.Controllers
{
    [Route("api/ArticulosVarios")]
    [ApiController]
    public class ArticulosVariosController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public ArticulosVariosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("ListarTodos")]
        public async Task<IEnumerable<ArticulosVarios>> ListarTodos() => await unitOfWork.ArticulosVariosRepositorio.GetAll();

        [HttpGet("ObtenerPorPatente")]
        public async Task<ActionResult<IEnumerable<ArticulosVariosRecurso>>> ObtenerPorPatente(string pPatente)
        {
            var articulosVarios = await unitOfWork.ArticulosVariosRepositorio.ObtenerPorPatente(pPatente);
            var articulosVariosRecurso = _mapper.Map<IEnumerable<ArticulosVarios>, IEnumerable<ArticulosVariosRecurso>>(articulosVarios);

            return Ok(articulosVariosRecurso);
        }

        [HttpGet("ObtenerPorLegajo")]
        public async Task<ActionResult<IEnumerable<ArticulosVariosRecurso>>> ObtenerPorLegajo(int pNroLegajo)
        {
            var articulosVarios = await unitOfWork.ArticulosVariosRepositorio.ObtenerPorLegajo(pNroLegajo);
            var articulosVariosRecurso = _mapper.Map<IEnumerable<ArticulosVarios>, IEnumerable<ArticulosVariosRecurso>>(articulosVarios);

            return Ok(articulosVariosRecurso);
        }
    }
}
