using Concesionarios.Core.Common;
using System.Collections.Generic;

namespace Concesionarios.Core
{
    public class Marca : BaseEntity
    {
        public string Nombre { get; set; }
        public virtual ICollection<Coche> Coches { get; set; }
    }
}
