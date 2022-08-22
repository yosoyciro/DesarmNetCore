using System;
using System.Collections.Generic;
using System.Text;
using webapi.core.Modelos;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace webapi.data.Repositorios
{
    public interface IVehiculosRepositorio : IRepositorio<Vehiculos>
    {
        //Task<IReadOnlyList<Vehiculos>> ObtenerPorPatente(string pPatente);
        //Task<Vehiculos> ObtenerPorPatenteConArticulosStock(string pPatente);
        //Task<Vehiculos> ObtenerPorIdConDatos(int pId);
        //Task<IReadOnlyList<Vehiculos>> ObtenerPorMarca(int pMarcasId);
        //Task<IReadOnlyList<Vehiculos>> ObtenerPorMarcaModelo(int pMarcasId, int pModelosId);
        //Task<IReadOnlyList<Vehiculos>> BuscarVehiculosMultiple(int pDepositosIslasUbicacionesId, string pPatente, int pMarcasId, int pModelosId, int pMostrarCompactados, string pNroChasis, int pLegajo, int pDepositosId);
        Task Actualizar(Vehiculos pVehiculo);
        Task ActualizarUbicacion(int pDepositosIslasUbicacionesId, Vehiculos pVehiculoActualizar);
        
        
    }
}
