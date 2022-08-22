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
    [Route("api/DepositosIslasUbicaciones")]
    [ApiController]
    public class DepositosIslasUbicacionesController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public DepositosIslasUbicacionesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("ListarTodos")]
        public async Task<IEnumerable<DepositosIslasUbicaciones>> ListarTodos() => await unitOfWork.DepositosIslasUbcacionesRepositorio.GetAll();

        [HttpGet("ListarUbicacionesLibres")]
        public async Task<IEnumerable<DepositosIslasUbicaciones>> ListarUbicacionesLibres() => await unitOfWork.DepositosIslasUbcacionesRepositorio.ListarUbicacionesLibres();

        [HttpGet("LibrePorPrioridad")]
        public async Task<DepositosIslasUbicaciones> LibrePorPrioridad() => await unitOfWork.DepositosIslasUbcacionesRepositorio.ObtenerUbicacionesLibres();
    }
}