using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.core.Modelos;

namespace webapi.data.Repositorios.Implementaciones
{
    public class DepositosIslasMapaRepositorio : Repositorio<DepositosIslasMapa>, IDepositosIslasMapaRepositorio
    {
        public DepositosIslasMapaRepositorio(DesarmDatacenterContext context) : base(context) { }



        private DesarmDatacenterContext DesarmDatacenterContext
        {
            get { return context as DesarmDatacenterContext; }
        }
    }
}
