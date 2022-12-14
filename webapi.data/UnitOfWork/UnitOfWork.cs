using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using webapi.data.Interfaces;
using webapi.data.Repositorios;
using webapi.data.Repositorios.Implementaciones;

namespace webapi.data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DesarmDatacenterContext _databaseContext;
        private ColoresRepositorio _coloresRepositorio;
        private CategoriasRepositorio _categoriasRepositorio;
        private CompaniasRepositorio _companiasRepositorio;
        private DepositosRepositorio _depositosRepositorio;
        private EmpleadosRepositorio _empladosRepositorio;
        private MarcasChasisRepositorio _marcasChasisRepositorio;
        private MarcasMotorRepositorio _marcasMotorRepositorio;
        private MarcasRepositorio _marcasRepositorio;
        private ModelosRepositorio _modelosRepositorio;
        private TiposCombustibleRepositorio _tiposCombustibleRepositorio;
        private VehiculosRepositorio _vehiculosRepositorio;
        private VehiculosTipoRepositorio _vehiculosTipoRepositorio;
        private Formulario04DRepositorio _formulario04DRepositorio;
        private DepositosIslasUbicacionesRepositorio _depositosIslasUbicacionesRepositorio;
        private DepositosIslasMapaRepositorio _depositosIslasMapaRepositorio;
        private ArticulosStockRepositorio _articulosStockRepositorio;
        private ArticulosDescarteRepositorio _articulosDescarteRepositorio;
        private DesarmeArtDesRepositorio _desarmeArtDesRepositorio;
        private DesarmeArtDesDetalleRepositorio _desarmeArtDesDetalleRepositorio;
        private RemitosRepositorio _remitosRepositorio;
        private ArticulosVariosRepositorio _articulosVariosRepositorio;

        public UnitOfWork(DesarmDatacenterContext databaseContext)
        { _databaseContext = databaseContext; }

        //Repositorios
        public IVehiculosRepositorio VehiculosRepositorio => _vehiculosRepositorio = _vehiculosRepositorio ?? new VehiculosRepositorio(_databaseContext);
        public ICategoriasRepositorio CategoriasRepositorio => _categoriasRepositorio = _categoriasRepositorio ?? new CategoriasRepositorio(_databaseContext);

        public IColoresRepositorio ColoresRepositorio => _coloresRepositorio ?? new ColoresRepositorio(_databaseContext);

        public ICompaniasRepositorio CompaniasRepositorio => _companiasRepositorio ?? new CompaniasRepositorio(_databaseContext);

        public IDepositosRepositorio DepositosRepositorio => _depositosRepositorio ?? new DepositosRepositorio(_databaseContext);

        public IEmpleadosRepositorio EmpleadosRepositorio => _empladosRepositorio ?? new EmpleadosRepositorio(_databaseContext);

        public IMarcasChasisRepositorio MarcasChasisRepositorio => _marcasChasisRepositorio ?? new MarcasChasisRepositorio(_databaseContext);

        public IMarcasMotorRepositorio MarcasMotorRepositorio => _marcasMotorRepositorio ?? new MarcasMotorRepositorio(_databaseContext);

        public IMarcasRepositorio MarcasRepositorio => _marcasRepositorio ?? new MarcasRepositorio(_databaseContext);

        public IModelosRepositorio ModelosRepositorio => _modelosRepositorio ?? new ModelosRepositorio(_databaseContext);

        public ITiposCombustibleRepositorio TiposCombustibleRepositorio => _tiposCombustibleRepositorio ?? new TiposCombustibleRepositorio(_databaseContext);

        public IVehiculosTipoRepositorio VehiculosTipoRepositorio => _vehiculosTipoRepositorio ?? new VehiculosTipoRepositorio(_databaseContext);
        public IFormulario04DRepositorio Formulario04DRepositorio => _formulario04DRepositorio ?? new Formulario04DRepositorio(_databaseContext);
        public IDepositosIslasUbcacionesRepositorio DepositosIslasUbcacionesRepositorio => _depositosIslasUbicacionesRepositorio ?? new DepositosIslasUbicacionesRepositorio(_databaseContext);
        public IDepositosIslasMapaRepositorio DepositosIslasMapaRepositorio => _depositosIslasMapaRepositorio ?? new DepositosIslasMapaRepositorio(_databaseContext);
        public IArticulosStockRepositorio ArticulosStockRepositorio => _articulosStockRepositorio ?? new ArticulosStockRepositorio(_databaseContext);
        public IArticulosDescarteRepositorio ArticulosDescarteRepositorio => _articulosDescarteRepositorio ?? new ArticulosDescarteRepositorio(_databaseContext);
        public IDesarmeArtDesRepositorio DesarmeArtDesRepositorio => _desarmeArtDesRepositorio ?? new DesarmeArtDesRepositorio(_databaseContext);
        public IDesarmeArtDesDetalleRepositorio DesarmeArtDesDetalleRepositorio => _desarmeArtDesDetalleRepositorio ?? new DesarmeArtDesDetalleRepositorio(_databaseContext);
        public IRemitosRepositorio RemitosRepositorio => _remitosRepositorio ?? new RemitosRepositorio(_databaseContext);
        public IArticulosVariosRepositorio ArticulosVariosRepositorio => _articulosVariosRepositorio ?? new ArticulosVariosRepositorio(_databaseContext);

        public async Task<int> CommitAsync()
        {
            return await _databaseContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _databaseContext.Dispose();
        }
    }
}