using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.core.Modelos;


namespace webapi.data.Configuraciones
{
    class ListasPreciosDescuentosConfiguracion : IEntityTypeConfiguration<ListasPreciosDescuentos>
    {
        public void Configure(EntityTypeBuilder<ListasPreciosDescuentos> builder)
        {
            builder
               .HasKey(v => v.Id).HasName("LISPREDESC_X_LISTASPRECIOSDESCUENTOSID");

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(v => v.Id).HasColumnName("LISTASPRECIOSDESCUENTOSID");

            builder
                .ToTable("ListasPreciosDescuentos");

        }
    }
}
