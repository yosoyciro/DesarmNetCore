using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.core.Modelos;
using webapi.root;
using AutoMapper;
using webapi.api.Recursos;
using webapi.data.Repositorios;

namespace webapi.api.Controllers
{
    [Route("api/Modelos")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public ModelosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("ListarTodos")]
        public async Task<IEnumerable<Modelos>> ListarTodos() => await unitOfWork.ModelosRepositorio.GetAll();
    }
}