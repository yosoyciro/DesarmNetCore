using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.core.Modelos;

namespace webapi.data.Repositorios.Implementaciones
{
    public class ColoresRepositorio : Repositorio<Colores>, IColoresRepositorio
    {
        public ColoresRepositorio(DesarmDatacenterContext context) : base(context) { }



        private DesarmDatacenterContext DesarmDatacenterContext
        {
            get { return context as DesarmDatacenterContext; }
        }
    }
}
