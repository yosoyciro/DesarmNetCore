using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi.core.Modelos;
using webapi.business.Servicios.Implementaciones;
using webapi.root;
using webapi.data.Repositorios;
using webapi.business.Servicios;
using AutoMapper;
using webapi.api.Recursos;
using webapi.api.Validadores;
using webapi.core.Specs.Implementaciones;
using webapi.api.Errors;

namespace webapi.api.Controllers
{
    [Route("api/Vehiculos")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private IVehiculosServicio _vehiculosServicios;
        private readonly IMapper _mapper;

        public VehiculosController(IVehiculosServicio _vehiculosServicios, IMapper mapper)
        {
            this._mapper = mapper;
            this._vehiculosServicios = _vehiculosServicios;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<VehiculosRecurso>>> Get([FromQuery] VehiculosParameters parameters)
        {
            var specs = new VehiculosConSpecs(parameters);
            var list = await _vehiculosServicios.GetAllWithSpecs(specs);

            if (list == null)
            {
                return NotFound(new CodeErrorResponse(404, "No hay vehiculos"));
            }

            return Ok(_mapper.Map<IReadOnlyList<Vehiculos>, IReadOnlyList<VehiculosRecurso>>(list));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculosRecurso>> Get(int id)
        {            
            var specs = new VehiculosConSpecs(id);
            var vehiculo = await _vehiculosServicios.GetByIdWithSpecs(specs);
            if (vehiculo == null)
            {
                return NotFound(new CodeErrorResponse(404, "No hay vehiculo"));
            }

            return Ok(_mapper.Map<Vehiculos, VehiculosRecurso>(vehiculo));
        }


        [HttpPut]
        public async Task<ActionResult<VehiculosRecurso>> ActualizarVehiculo(int pId, [FromBody] VehiculoGuardarRecurso pVehiculo)
        {
            //Validaciones
            var validator = new VehiculoGuardarRecursoValidador();
            var validador = await validator.ValidateAsync(pVehiculo);

            if (!validador.IsValid)
                return BadRequest(validador.Errors);

            //Guardo
            //var vehiculo = await _vehiculosServicios.GetById(pId);

            //if (vehiculo == null)
            //{
            //    return NotFound();
            //}

            var vehiculoUpdate = _mapper.Map<VehiculoGuardarRecurso, Vehiculos>(pVehiculo);
            await _vehiculosServicios.Actualizar(vehiculoUpdate);

            var specs = new VehiculosConSpecs(pVehiculo.Id);
            var vehiculoActualizado = await _vehiculosServicios.GetByIdWithSpecs(specs);

            var vehiculoActualizadoRecurso = _mapper.Map<Vehiculos, VehiculosRecurso>(vehiculoActualizado);

            return Ok(vehiculoActualizadoRecurso);
        }

        [HttpPut("ActualizarDepositosIslasUbicaciones")]
        public async Task<ActionResult<VehiculosRecurso>> ActualizarDepositosIslasUbicaciones(int pId, int pDepositosIslasUbicacionesId)
        {            
            //Guardo
            var vehiculoActualizar = await _vehiculosServicios.GetById(pId);

            if (vehiculoActualizar == null)
            {
                return NotFound();
            }

            await _vehiculosServicios.ActualizarDepositosIslasUbicaciones(vehiculoActualizar, pDepositosIslasUbicacionesId);

            var specs = new VehiculosConSpecs(pId);
            var vehiculoActualizado = await _vehiculosServicios.GetByIdWithSpecs(specs);

            var vehiculoActualizadoRecurso = _mapper.Map<Vehiculos, VehiculosRecurso>(vehiculoActualizado);

            return Ok(vehiculoActualizadoRecurso);
        }

        [HttpPost]
        public async Task<ActionResult<VehiculosRecurso>> AgregarVehiculo([FromBody] VehiculoGuardarRecurso pVehiculo)
        {
            //Validaciones
            var validator = new VehiculoGuardarRecursoValidador();
            var validador = await validator.ValidateAsync(pVehiculo);

            if (!validador.IsValid)
                return BadRequest(validador.Errors);

            //Guardo
            try
            {
                var vehiculoCrear = _mapper.Map<VehiculoGuardarRecurso, Vehiculos>(pVehiculo);

                var vehiculoNuevo = await _vehiculosServicios.AgregarAsync(vehiculoCrear);
                var vehiculo = await _vehiculosServicios.GetById(vehiculoNuevo.Id);
                var vehiculoRecurso = _mapper.Map<Vehiculos, VehiculosRecurso>(vehiculo);

                return Ok(vehiculoRecurso);
            }
            catch (Exception ex)
            {
                return Content(ex.InnerException.Message);                
            }
            
        }
    }
}