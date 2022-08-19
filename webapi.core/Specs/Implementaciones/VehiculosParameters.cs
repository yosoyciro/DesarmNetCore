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
    public class VehiculosParameters : BaseSpecificationParameters<Vehiculos>
    {
        public string? Patente { get; set; }
        public int? DepositosIslasUbicacionesId { get; set; }
        public int? MarcasId { get; set; }
        public int? ModelosId { get; set; }
        public string? NroChasis { get; set; }
        public int? Legajo { get; set; }
        public int? DepositosId { get; set; }
        public Int16? MostrarCompactados { get; set; }

        public override Expression<Func<Vehiculos, bool>> GetCriteria()
        {
            return r => (string.IsNullOrEmpty(Patente) || r.Patente.Contains(Patente))
            && (!MarcasId.HasValue || r.Marcasid == MarcasId)
            && (!DepositosIslasUbicacionesId.HasValue || r.DepositosIslasUbicacionesId == DepositosIslasUbicacionesId)
            && (!ModelosId.HasValue || r.Modelosid == ModelosId)
            && (string.IsNullOrEmpty(NroChasis) || r.Chasis.Contains(NroChasis))
            && (!Legajo.HasValue || r.Formulario04D.NROLEGAJO == Legajo)
            && (!DepositosId.HasValue || r.Depositosid == DepositosId)
            && (!MostrarCompactados.HasValue || r.Vehiculoscompactadosid >= MostrarCompactados);
        }
    }
}
