using Concesionarios.Core;
using System.Data.Entity.ModelConfiguration;

namespace Concesionarios.DAL.Mapping
{
    public class CocheMap : EntityTypeConfiguration<Coche>
    {
        public CocheMap()
        {
            HasKey(c => c.Id);
            Property(c => c.Matricula).HasMaxLength(10); //TODO: mirar REGEX
            HasRequired(c => c.Concesionario).WithRequiredDependent();
            HasRequired(c => c.Marca).WithRequiredDependent();
            ToTable("Coche");
        }
    }
}
