using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi.core.Modelos;
using webapi.root;
using webapi.data.Repositorios;
using AutoMapper;
using webapi.api.Recursos;
using webapi.api.Validadores;

namespace webapi.api.Controllers
{
    [Route("api/Remitos")]
    [ApiController]
    public class RemitosController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public RemitosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("ObtenerPorIdConDetalle")]
        public async Task<ActionResult<RemitosRecurso>> ObtenerPorIdConDetalle(int pRemitosId)
        {
            var remito = await unitOfWork.RemitosRepositorio.ObtenerPorIdConDetalle(pRemitosId);
            var remitoRecurso = _mapper.Map<Remitos, RemitosRecurso>(remito);

            return Ok(remitoRecurso);
        }

        [HttpPost("Agregar")]
        public async Task<ActionResult<RemitoGuardarRecurso>> AgregarRemito([FromBody] RemitoGuardarRecurso pRemito)
        {
            //Guardo
            try
            {
                var remitoCrear = _mapper.Map<RemitoGuardarRecurso, Remitos>(pRemito);

                var remitoNuevo = unitOfWork.RemitosRepositorio.AgregarAsync(remitoCrear);
                var remito = await unitOfWork.RemitosRepositorio.ObtenerPorIdConDetalleYAuditoria(remitoNuevo.Id);
                var remitoRecurso = _mapper.Map<Remitos, RemitosRecurso>(remito);

                return Ok(remitoRecurso);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);  //Content( ex.InnerException.Message);
            }

        }

        [HttpPut("Anular")]
        public async Task<ActionResult<RemitosRecurso>> AnularRemito(int pId)
        {
            //Guardo
            var remitoAnular = await unitOfWork.RemitosRepositorio.ObtenerPorIdConDetalle(pId);

            if (remitoAnular == null)
            {
                return NotFound();
            }
            
            await unitOfWork.RemitosRepositorio.Anular(remitoAnular);
            await unitOfWork.CommitAsync();

            var remitoActualizado = await unitOfWork.RemitosRepositorio.ObtenerPorIdConDetalle(pId);

            var remitoActualizadoRecurso = _mapper.Map<Remitos, RemitosRecurso>(remitoActualizado);

            return Ok(remitoActualizadoRecurso);
        }
    }
}
