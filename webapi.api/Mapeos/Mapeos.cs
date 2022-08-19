using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.api.Recursos;
using AutoMapper;
using webapi.core.Modelos;

namespace webapi.api.Mapeos
{
    public class Mapeos : Profile
    {
        public Mapeos()
        {
             // Domain to Resource
            CreateMap<Vehiculos, VehiculosRecurso>()
                .ForMember(vr => vr.VehiculosId, x => x.MapFrom(v => v.Id)).ReverseMap();

            CreateMap<Marcas, MarcasRecurso>().ReverseMap();
            CreateMap<Modelos, ModelosRecurso>().ReverseMap();
            CreateMap<TiposCombustible, TiposCombustibleRecurso>().ReverseMap();
            CreateMap<VehiculosTipo, VehiculosTipoRecurso>()
                .ForMember(vt => vt.VehiculosTipoId, x => x.MapFrom(a => a.Id))
                .ReverseMap();

            CreateMap<Categorias, CategoriasRecurso>().ReverseMap();
            CreateMap<Colores, ColoresRecurso>().ReverseMap();
            CreateMap<Companias, CompaniasRecurso>().ReverseMap();
            CreateMap<Depositos, DepositosRecurso>().ReverseMap();
            CreateMap<Empleados, EmpleadosRecurso>().ReverseMap();
            CreateMap<MarcasChasis, MarcasChasisRecurso>().ReverseMap();
            CreateMap<MarcasMotor, MarcasMotorRecurso>().ReverseMap();
            CreateMap<Formulario04D, Formulario04DRecurso>().ReverseMap();
            CreateMap<DepositosIslasUbicaciones, DepositosIslasUbicacionesRecurso>().ReverseMap();
            CreateMap<DepositosIslasMapa, DepositosIslasMapaRecursos>().ReverseMap();
            CreateMap<ArticulosStock, ArticulosStockRecurso>().ReverseMap();
            CreateMap<ArticulosDescarte, ArticulosDescarteRecurso>().ReverseMap();
            CreateMap<DesarmeArtDes, DesarmeArtDesRecurso>().ReverseMap();
            CreateMap<DesarmeArtDesDetalle, DesarmeArtDesDetalleRecurso>().ReverseMap();
            CreateMap<Remitos, RemitosRecurso>().ReverseMap();
            CreateMap<RemitosDetalle, RemitosDetalleRecurso>().ReverseMap();
            CreateMap<RemitosAuditoria, RemitosAuditoriaRecurso>().ReverseMap();
            CreateMap<Articulos, ArticulosRecurso>().ReverseMap();
            CreateMap<ArticulosVarios, ArticulosVariosRecurso>()
                .ForMember(av => av.ARTICULOSVARIOSID, x => x.MapFrom(av => av.Id))
                .ForMember(av => av.ARTICULOSID, x => x.MapFrom(a => a.Articulos.Id))
                .ForMember(av => av.ARTICULOSDESCRIPCION, x => x.MapFrom(a => a.Articulos.DESCRIPCION))
                .ForMember(av => av.Patente, x => x.MapFrom(a => a.Vehiculos.Patente))
                .ForMember(av => av.Motor, x => x.MapFrom(a => a.Vehiculos.Motor))
                .ForMember(av => av.NroLegajo, x => x.MapFrom(a => a.Vehiculos.Formulario04D.NROLEGAJO))
                .ForMember(av => av.VEHICULOSTIPODESCRIPCION, x => x.MapFrom(a => a.Vehiculos.VehiculosTipo.Descripcion))
                .ReverseMap();

            //Save resources
            CreateMap<VehiculoGuardarRecurso, Vehiculos>().ReverseMap();
            CreateMap<RemitoGuardarRecurso, Remitos>().ReverseMap();
            CreateMap<RemitosDetalleGuardarRecurso, RemitosDetalle>().ReverseMap();
            CreateMap<RemitosAuditoriaRecurso, RemitosAuditoria>().ReverseMap();
        }
    }
}
