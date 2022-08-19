using System;

namespace webapi.api.Recursos
{
    public class ArticulosVariosRecurso
    {
        public int ARTICULOSVARIOSID { get; set; }
        //public ArticulosRecurso Articulos { get; set; }
        public int ARTICULOSID { get; set; }
        public string ARTICULOSDESCRIPCION { get; set; }       
        //public VehiculosRecurso Vehiculos { get; set; }
        public int VehiculosId { get; set; }
        public int NroLegajo { get; set; }
        public string Patente { get; set; }
        public string MARCA { get; set; }
        public string MODELO { get; set; }
        public Int16 ANIO { get; set; }
        public string Motor { get; set; }
        public string VEHICULOSTIPODESCRIPCION { get; set; }
        public string OBSERVACIONES { get; set; }
        public int ESTADOSID { get; set; }
        public int SECTORESID { get; set; }
        public decimal PRECIOVENTA { get; set; }
    }
}
