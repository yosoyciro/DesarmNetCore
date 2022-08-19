using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using webapi.core.Modelos;
using webapi.data.Repositorios;
using webapi.data.Repositorios.Implementaciones;
using webapi.data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using webapi.core.Specs.Implementaciones;

namespace webapi.business.Servicios.Implementaciones
{
    public class VehiculosServicio : IVehiculosServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehiculosServicio(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Actualizar(Vehiculos vehiculo)
        {
            try
            {
                _unitOfWork.VehiculosRepositorio.Actualizar(vehiculo);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task ActualizarDepositosIslasUbicaciones(Vehiculos pVehiculoActualizar, int pDepositosIslasUbicacionesId)
        {
            try
            {
                pVehiculoActualizar.DepositosIslasUbicacionesId = pDepositosIslasUbicacionesId;
                _unitOfWork.VehiculosRepositorio.Actualizar(pVehiculoActualizar);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Vehiculos> AgregarAsync(Vehiculos pVehiculo)
        {
            try
            {
                await _unitOfWork.VehiculosRepositorio.AgregarAsync(pVehiculo);
                await _unitOfWork.CommitAsync();

                return pVehiculo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IReadOnlyList<Vehiculos>> GetAllWithSpecs(VehiculosConSpecs specs)
        {
            return await _unitOfWork.VehiculosRepositorio.GetAllWithSpecs(specs);
        }

        public async Task<Vehiculos> GetById(int pId)
        {
            return await _unitOfWork.VehiculosRepositorio.GetById(pId);
        }

        public async Task<Vehiculos> GetByIdWithSpecs(VehiculosConSpecs specs)
        {
            return await _unitOfWork.VehiculosRepositorio.GetByIdWithSpecs(specs);
        }
    }
}
