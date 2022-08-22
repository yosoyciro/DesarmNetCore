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
    [Route("api/DesarmeArtDes")]
    [ApiController]
    public class DesarmeArtDesController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public DesarmeArtDesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("ListarTodos")]
        public async Task<IEnumerable<DesarmeArtDes>> ListarTodos() => await unitOfWork.DesarmeArtDesRepositorio.GetAll();

        [HttpGet("ObtenerPorVehiculo")]
        public async Task<ActionResult<DesarmeArtDesRecurso>> ObtenerPorVehiculo(int pVehiculosId)
        {
            var desarmeArtDes = await unitOfWork.DesarmeArtDesRepositorio.ObtenerPorVehiculo(pVehiculosId);
            var desarmeArtDesRecurso = _mapper.Map<DesarmeArtDes, DesarmeArtDesRecurso>(desarmeArtDes);

            return Ok(desarmeArtDesRecurso);

        }
        //[HttpPut("Actualizar")]
        //public async Task<ActionResult<DesarmeArtDesRecurso>> ActualizarVehiculo(int pId, [FromBody] DesarmeArtDesRecurso pDesarmeArtDes)
        //{
        //    //Guardo
        //    var desarmeArtDesActualizar = await unitOfWork.DesarmeArtDesRepositorio.ObtenerPorIdConDatos(pId);

        //    if (desarmeArtDesActualizar == null)
        //    {
        //        return NotFound();
        //    }

        //    var desarmeArtDes = _mapper.Map<DesarmeArtDesRecurso, DesarmeArtDes>(pDesarmeArtDes);
        //    await unitOfWork.DesarmeArtDesRepositorio.(desarmeArtDesActualizar, desarmeArtDes);

        //    var desarmeArtDesActualizado = await _desarmeArtDesServicio.ObtenerPorIdConDatos(pId);

        //    var desarmeArtDesActualizadoRecurso = _mapper.Map<DesarmeArtDes, DesarmeArtDesRecurso>(desarmeArtDesActualizado);

        //    return Ok(desarmeArtDesActualizadoRecurso);
        //}
    }
}
