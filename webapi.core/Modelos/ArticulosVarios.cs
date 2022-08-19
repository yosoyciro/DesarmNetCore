using System;
using System.Collections.Generic;
using System.Text;

namespace webapi.core.Modelos
{
    public class ArticulosVarios : BaseEntity
    {
        public ArticulosVarios()
        {
            //Vehiculos = new Vehiculos();
            //Articulos = new Articulos();
        }
        public int ARTICULOSID { get; set; }
        public Articulos Articulos { get; set; }
        public int VEHICULOSID { get; set; }
        public Vehiculos Vehiculos { get; set; }
        public string MARCA { get; set; }
        public string MODELO { get; set; }
        public Int16 ANIO { get; set; }   
        public string OBSERVACIONES { get; set; }
        public int ESTADOSID { get; set; }
        public int SECTORESID { get; set; }
        public decimal PRECIOVENTA { get; set; }
    }
}
