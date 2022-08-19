using System;
using System.Collections.Generic;
using System.Text;

namespace webapi.core.Modelos
{
    public class ListasPreciosDescuentos : BaseEntity
    {        
        public int LISTASPRECIOSID { get; set; }
        public int RANGO { get; set; }
        public string RANGOTIPO { get; set; }
        public Decimal PORCENTAJEAJUSTE { get; set; }
        public int VIGENTEDESDE { get; set; }
    }
}
