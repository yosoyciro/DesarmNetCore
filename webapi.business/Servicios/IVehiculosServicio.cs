using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using webapi.core.Modelos;
using webapi.core.Specs.Implementaciones;

namespace webapi.business.Servicios
{
    public interface IVehiculosServicio
    {
        Task<IReadOnlyList<Vehiculos>> GetAllWithSpecs(VehiculosConSpecs specs);
        Task<Vehiculos> GetById(int pId);
        Task<Vehiculos> GetByIdWithSpecs(VehiculosConSpecs specs);
        Task Actualizar(Vehiculos vehiculo);
        Task<Vehiculos> AgregarAsync(Vehiculos pVehiculo);
        Task ActualizarDepositosIslasUbicaciones(Vehiculos pVehiculoActualizar, int pDepositosIslasUbicacionesId);
    }
}
