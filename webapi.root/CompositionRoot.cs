using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using webapi.data;
using webapi.data.Repositorios;
using webapi.data.Repositorios.Implementaciones;
using Microsoft.Extensions.Configuration;
using webapi.data.Interfaces;

namespace webapi.root
{
    public class CompositionRoot
    {
        public CompositionRoot() {}

        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DesarmDatacenterContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("ConexionDesarmDatacenter")));
            services.AddScoped<DesarmDatacenterContext>();
            services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
           

            //Unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}