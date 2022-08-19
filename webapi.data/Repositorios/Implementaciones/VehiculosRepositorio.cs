using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace webapi.data.Repositorios.Implementaciones
{
    public class VehiculosRepositorio : Repositorio<Vehiculos>, IVehiculosRepositorio
    {
        public VehiculosRepositorio(DesarmDatacenterContext context) : base(context) { }
        
        private DesarmDatacenterContext DesarmDatacenterContext
        {
            get { return context as DesarmDatacenterContext; }
        }

        public void Actualizar(Vehiculos pVehiculo)
        {            
            context.Entry(pVehiculo).State = EntityState.Modified;
        }

        public Task ActualizarUbicacion()
        {
            throw new NotImplementedException();
        }
    }
}
