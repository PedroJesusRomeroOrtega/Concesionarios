using Concesionarios.Core;
using System.Data.Entity.ModelConfiguration;

namespace Concesionarios.DAL.Mapping
{
    public class ConcesionarioMap : EntityTypeConfiguration<Concesionario>
    {
        public ConcesionarioMap()
        {
            HasKey(c => c.Id);
            Property(c => c.Nombre)
                .HasMaxLength(100)
                .IsRequired();
            Property(c => c.Direccion)
                .HasMaxLength(300);
            
    
            ToTable("Concesionario");
        }
    }
}
