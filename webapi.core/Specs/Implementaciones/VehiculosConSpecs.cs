using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using webapi.core.Modelos;
using webapi.Core.Specs;

namespace webapi.core.Specs.Implementaciones
{
    public class VehiculosConSpecs : BaseSpecification<Vehiculos>
    {
        public VehiculosConSpecs(VehiculosParameters parameters) : base(parameters)
        {
            AddInclude(x => x.Marcas);
            AddInclude(x => x.Modelos);
            AddInclude(x => x.TiposCombustible);
            AddInclude(v => v.Companias);
            AddInclude(v => v.Colores);
            AddInclude(v => v.Categorias);
            AddInclude(v => v.Depositos);
            AddInclude(v => v.Empleados);
            AddInclude(v => v.MarcasChasis);
            AddInclude(v => v.MarcasMotor);
            AddInclude(v => v.VehiculosTipo);
            AddInclude(v => v.DepositosIslasUbicaciones);
            AddInclude(v => v.Formulario04D);
        }

        public VehiculosConSpecs(int pId) : base(x => x.Id == pId)
        {
            AddInclude(x => x.Marcas);
            AddInclude(x => x.Modelos);
            AddInclude(x => x.TiposCombustible);
            AddInclude(v => v.Companias);
            AddInclude(v => v.Colores);
            AddInclude(v => v.Categorias);
            AddInclude(v => v.Depositos);
            AddInclude(v => v.Empleados);
            AddInclude(v => v.MarcasChasis);
            AddInclude(v => v.MarcasMotor);
            AddInclude(v => v.VehiculosTipo);
            AddInclude(v => v.DepositosIslasUbicaciones);
            AddInclude(v => v.Formulario04D);
        }
    }
}
