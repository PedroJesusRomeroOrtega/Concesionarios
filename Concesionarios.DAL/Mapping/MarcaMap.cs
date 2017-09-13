using Concesionarios.Core;
using System.Data.Entity.ModelConfiguration;

namespace Concesionarios.DAL.Mapping
{
    public class MarcaMap : EntityTypeConfiguration<Marca>
    {
        public MarcaMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Nombre).IsRequired().HasMaxLength(100);
            ToTable("Marca");
        }
    }
}
