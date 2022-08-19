using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.core.Modelos;
using webapi.data.Configuraciones;

namespace webapi.data
{
    public class DesarmDatacenterContext : DbContext
    {        
        public DesarmDatacenterContext(DbContextOptions<DesarmDatacenterContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {            
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Colores> Colores { get; set; }
        public virtual DbSet<Companias> Companias { get; set; }
        public virtual DbSet<Depositos> Depositos { get; set; }
        public virtual DbSet<Empleados> CoEmpleadosmpanias { get; set; }
        public virtual DbSet<MarcasChasis> MarcasChasis { get; set; }
        public virtual DbSet<MarcasMotor> MarcasMotor { get; set; }
        public virtual DbSet<Marcas> Marcas { get; set; }
        public virtual DbSet<Modelos> Modelos { get; set; }
        public virtual DbSet<TiposCombustible> TiposCombustible { get; set; }
        public virtual DbSet<Vehiculos> Vehiculos { get; set; }
        public virtual DbSet<VehiculosTipo> VehiculosTipo { get; set; }
        public virtual DbSet<Formulario04D> Formulario04D { get; set; }
        public virtual DbSet<DepositosIslasMapa> DepositosIslasMapa { get; set; }
        public virtual DbSet<DepositosIslasUbicaciones> DepositosIslasUbicaciones { get; set; }
        public virtual DbSet<ArticulosStock> ArticulosStock { get; set; }
        public virtual DbSet<ArticulosDescarte> ArticulosDescarte { get; set; }
        public virtual DbSet<DesarmeArtDes> DesarmeArtDes { get; set; }
        public virtual DbSet<DesarmeArtDesDetalle> DesarmeArtDesDetalle { get; set; }
        public virtual DbSet<Remitos> Remitos { get; set; }
        public virtual DbSet<RemitosDetalle> RemitosDetalle { get; set; }
        public virtual DbSet<RemitosAuditoria> RemitosAuditoria { get; set; }
        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<ListasPreciosDescuentos> ListasPreciosDescuentos { get; set; }
        public virtual DbSet<ArticulosVarios> ArticulosVarios { get; set; }
    }
}
