using Concesionarios.Core;
using System.Data.Entity.ModelConfiguration;

namespace Concesionarios.DAL.Mapping
{
    public class AuditoriaMap : EntityTypeConfiguration<Auditoria>
    {
        public AuditoriaMap()
        {
            Property(a => a.Fecha).IsRequired();
            Property(a => a.Modelo).IsRequired();
            Property(a => a.Accion).IsRequired();
            //HasOptional(a => a.Coche);
            //HasOptional(a => a.Concesionario);
            ToTable("Auditoria");
        }
    }
}
