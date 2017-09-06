using Concesionarios.Core;
using Concesionarios.Core.Common;
using Concesionarios.Core.Enum;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace Concesionarios.DAL
{
    public class ConcesionariosDbContext : DbContext, IConcesionariosDbContext
    {
        public ConcesionariosDbContext() : base("name=DbConnectionString")
        {
            Database.SetInitializer<ConcesionariosDbContext>(new DropCreateDatabaseIfModelChanges<ConcesionariosDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public override int SaveChanges()
        {
            //TODO: Buscar otra forma más elegante de hacer la auditoría.
            var now = DateTime.UtcNow;
            var setAuditoria = Set<Auditoria>();

            /*****************/
            /*AUDITORIA COCHE*/
            var addedAuditedCocheEntities = ChangeTracker.Entries<Coche>()
                                        .Where(p => p.State == EntityState.Added)
                                        .Select(p => p.Entity);

            var modifiedAuditedCocheEntities = ChangeTracker.Entries<Coche>()
                                          .Where(p => p.State == EntityState.Modified)
                                          .Select(p => p.Entity);

            var deletedAuditedCocheEntities = ChangeTracker.Entries<Coche>()
                                         .Where(p => p.State == EntityState.Deleted)
                                         .Select(p => p.Entity);

            foreach (var added in addedAuditedCocheEntities)
            {
                setAuditoria.Add(new Auditoria() { Fecha = now, Accion = Accion.Insert, Modelo = Modelo.Coche, Coche = added });
            }

            foreach (var modified in modifiedAuditedCocheEntities)
            {
                setAuditoria.Add(new Auditoria() { Fecha = now, Accion = Accion.Edit, Modelo = Modelo.Coche, Coche = modified });
            }

            foreach (var deleted in deletedAuditedCocheEntities)
            {
                setAuditoria.Add(new Auditoria() { Fecha = now, Accion = Accion.Delete, Modelo = Modelo.Coche, Coche = deleted });
            }

            /*************************/
            /*AUDITORIA CONCESIONARIO*/
            var addedAuditedConcesionarioEntities = ChangeTracker.Entries<Concesionario>()
                                     .Where(p => p.State == EntityState.Added)
                                     .Select(p => p.Entity);

            var modifiedAuditedConcesionarioEntities = ChangeTracker.Entries<Concesionario>()
                                          .Where(p => p.State == EntityState.Modified)
                                          .Select(p => p.Entity);

            var deletedAuditedConcesionarioEntities = ChangeTracker.Entries<Concesionario>()
                                         .Where(p => p.State == EntityState.Deleted)
                                         .Select(p => p.Entity);

            foreach (var added in addedAuditedConcesionarioEntities)
            {
                setAuditoria.Add(new Auditoria() { Fecha = now, Accion = Accion.Insert, Modelo = Modelo.Concesionario, Concesionario = added });
            }

            foreach (var modified in modifiedAuditedConcesionarioEntities)
            {
                setAuditoria.Add(new Auditoria() { Fecha = now, Accion = Accion.Edit, Modelo = Modelo.Concesionario, Concesionario = modified });
            }

            foreach (var deleted in deletedAuditedConcesionarioEntities)
            {
                setAuditoria.Add(new Auditoria() { Fecha = now, Accion = Accion.Delete, Modelo = Modelo.Concesionario, Concesionario = deleted });
            }


            return base.SaveChanges();
        }
    }
}
