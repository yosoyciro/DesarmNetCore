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
    [Route("api/MarcasMotor")]
    [ApiController]
    public class MarcasMotorController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public MarcasMotorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("ListarTodos")]
        public async Task<IEnumerable<MarcasMotor>> ListarTodos() => await unitOfWork.MarcasMotorRepositorio.GetAll();
    }
}