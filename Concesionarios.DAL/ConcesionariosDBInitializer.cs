using Concesionarios.Core;
using System.Data.Entity;

namespace Concesionarios.DAL
{
    public class ConcesionariosDBInitializer : DropCreateDatabaseIfModelChanges<ConcesionariosDbContext>
    {
        protected override void Seed(ConcesionariosDbContext context)
        {
            //TODO:Revisar dbinitializer que no sé si hay otra forma mejor de poner el context.set
            var Marcas = context.Set<Marca>();
            Marcas.Add(new Marca() { Nombre = "Audi" });
            Marcas.Add(new Marca() { Nombre = "Volkswagen" });
            Marcas.Add(new Marca() { Nombre = "Seat" });

            base.Seed(context);
            //context.SaveChanges();
        }
    }
}
