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
            int numcoches = this.Set<Coche>().Count();//para forzar que se inicialize la base de datos
            this.Database.Initialize(true);
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
            var now = DateTime.UtcNow;
            var setAuditoria = Set<Auditoria>();

            /*****************/
            /*AUDITORIA COCHE*/
            var añadirCochesAuditados = ChangeTracker.Entries<Coche>()
                                        .Where(p => p.State == EntityState.Added)
                                        .Select(p => p.Entity);

            var modificarCochesAuditados = ChangeTracker.Entries<Coche>()
                                          .Where(p => p.State == EntityState.Modified)
                                          .Select(p => p.Entity);

            var borrarCochesAuditados = ChangeTracker.Entries<Coche>()
                                         .Where(p => p.State == EntityState.Deleted)
                                         .Select(p => p.Entity);

            foreach (var added in añadirCochesAuditados)
            {
                setAuditoria.Add(new Auditoria() { Fecha = now, Accion = Accion.Insert, Modelo = Modelo.Coche });
            }

            foreach (var modified in modificarCochesAuditados)
            {
                setAuditoria.Add(new Auditoria() { Fecha = now, Accion = Accion.Edit, Modelo = Modelo.Coche });
            }

            foreach (var deleted in borrarCochesAuditados)
            {
                setAuditoria.Add(new Auditoria() { Fecha = now, Accion = Accion.Delete, Modelo = Modelo.Coche });
            }

            /*************************/
            /*AUDITORIA CONCESIONARIO*/
            var añadirConcesionariosAuditados = ChangeTracker.Entries<Concesionario>()
                                     .Where(p => p.State == EntityState.Added)
                                     .Select(p => p.Entity);

            var modificarConcesionariosAuditados = ChangeTracker.Entries<Concesionario>()
                                          .Where(p => p.State == EntityState.Modified)
                                          .Select(p => p.Entity);

            var eliminarConcesionariosAuditados = ChangeTracker.Entries<Concesionario>()
                                         .Where(p => p.State == EntityState.Deleted)
                                         .Select(p => p.Entity);

            foreach (var added in añadirConcesionariosAuditados)
            {
                setAuditoria.Add(new Auditoria() { Fecha = now, Accion = Accion.Insert, Modelo = Modelo.Concesionario });
            }

            foreach (var modified in modificarConcesionariosAuditados)
            {
                setAuditoria.Add(new Auditoria() { Fecha = now, Accion = Accion.Edit, Modelo = Modelo.Concesionario });
            }

            foreach (var deleted in eliminarConcesionariosAuditados)
            {
                setAuditoria.Add(new Auditoria() { Fecha = now, Accion = Accion.Delete, Modelo = Modelo.Concesionario });
            }


            return base.SaveChanges();
        }
    }
}
