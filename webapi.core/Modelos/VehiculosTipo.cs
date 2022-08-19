using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace webapi.core.Modelos
{
    public class VehiculosTipo : BaseEntity
    {
        public VehiculosTipo()
        { }
        public string Descripcion { get; set; }
        public List<Vehiculos> Vehiculos { get; set; }
    }
}
