using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.core.Modelos;

namespace webapi.data.Configuraciones
{
    public class ArticulosVariosConfiguracion : IEntityTypeConfiguration<ArticulosVarios>
    {
        public void Configure(EntityTypeBuilder<ArticulosVarios> builder)
        {
            builder
                .HasKey(v => v.Id).HasName("ARTVAR_X_ARTICULOSVARIOSID");

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(v => v.Id).HasColumnName("ARTICULOSVARIOSID");

            //Relaciones
            builder
                .HasOne(v => v.Vehiculos)
                .WithMany(m => m.ArticulosVarios)
                .HasForeignKey(v => v.VEHICULOSID);

            builder
                .HasOne(ars => ars.Articulos)
                .WithMany(a => a.ArticulosVarios)
                .HasForeignKey(ars => ars.ARTICULOSID);

            builder
                .ToTable("ArticulosVarios");
        }
    }
}
