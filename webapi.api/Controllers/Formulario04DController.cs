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
    [Route("api/Formulario04D")]
    [ApiController]
    public class Formulario04DController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public Formulario04DController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("ListarTodos")]
        public async Task<ActionResult<IEnumerable<Formulario04DRecurso>>> ListarTodos()
        {
            var formulario04D = await unitOfWork.Formulario04DRepositorio.GetAll();
            var formulario04DRecurso = _mapper.Map<IEnumerable<Formulario04D>, IEnumerable<Formulario04DRecurso>>(formulario04D);

            return Ok(formulario04DRecurso);
        }     
        
        [HttpGet("ObtenerPorVehiculo")]
        public async Task<ActionResult<Formulario04DRecurso>> ObtenerPorVehiculo(int pVehiculosId)
        {
            var formulario04D = await unitOfWork.Formulario04DRepositorio.ObtenerPorVehiculo(pVehiculosId);
            var formulario04DRecurso = _mapper.Map<Formulario04D, Formulario04DRecurso>(formulario04D);

            return Ok(formulario04DRecurso);
        }
    }
}