using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.core.Modelos;
using AutoMapper;
using webapi.api.Recursos;
using webapi.data.Repositorios;

namespace webapi.api.Controllers
{
    [Route("api/TiposCombustible")]
    [ApiController]
    public class TiposCombustibleController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public TiposCombustibleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("ListarTodos")]
        public async Task<IEnumerable<TiposCombustible>> ListarTodos() => await unitOfWork.TiposCombustibleRepositorio.GetAll();
    }
}