using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.core.Modelos;
using webapi.business.Servicios.Implementaciones;
using webapi.root;
using webapi.data.Repositorios;
using webapi.business.Servicios;
using AutoMapper;
using webapi.api.Recursos;

namespace webapi.api.Controllers
{
    [Route("api/ArticulosVarios")]
    [ApiController]
    public class ArticulosVariosController : ControllerBase
    {
        private IArticulosVariosServicio _articulosVariosServicio;
        private readonly IMapper _mapper;

        public ArticulosVariosController(IArticulosVariosServicio articulosVariosServicio, IMapper mapper)
        {
            this._mapper = mapper;
            this._articulosVariosServicio = articulosVariosServicio;
        }

        [HttpGet("ListarTodos")]
        public async Task<IEnumerable<ArticulosVarios>> ListarTodos() => await _articulosVariosServicio.ListarTodos();

        [HttpGet("ObtenerPorPatente")]
        public async Task<ActionResult<IEnumerable<ArticulosVariosRecurso>>> ObtenerPorPatente(string pPatente)
        {
            var articulosVarios = await _articulosVariosServicio.ObtenerPorPatente(pPatente);
            var articulosVariosRecurso = _mapper.Map<IEnumerable<ArticulosVarios>, IEnumerable<ArticulosVariosRecurso>>(articulosVarios);

            return Ok(articulosVariosRecurso);
        }

        [HttpGet("ObtenerPorLegajo")]
        public async Task<ActionResult<IEnumerable<ArticulosVariosRecurso>>> ObtenerPorLegajo(int pNroLegajo)
        {
            var articulosVarios = await _articulosVariosServicio.ObtenerPorLegajo(pNroLegajo);
            var articulosVariosRecurso = _mapper.Map<IEnumerable<ArticulosVarios>, IEnumerable<ArticulosVariosRecurso>>(articulosVarios);

            return Ok(articulosVariosRecurso);
        }
    }
}
