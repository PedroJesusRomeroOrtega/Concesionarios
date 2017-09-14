using Concesionarios.Core;
using System.Data.Entity.ModelConfiguration;

namespace Concesionarios.DAL.Mapping
{
    public class CocheMap : EntityTypeConfiguration<Coche>
    {
        public CocheMap()
        {
            HasKey(c => c.Id);
            Property(c => c.Matricula)
                .HasMaxLength(10);
            //HasRequired(c => c.Concesionario).WithRequiredDependent();
            //HasRequired(c => c.Concesionario).WithMany(con => (ICollection<Coche>)con.Coches).HasForeignKey(c => c.Concesionario);
            //HasRequired(c => c.Marca).WithMany(m => (ICollection<Coche>)m.Coches).HasForeignKey(c => c.Marca);

            ToTable("Coche");
        }
    }
}
