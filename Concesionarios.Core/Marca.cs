using Concesionarios.Core.Common;
using System.Collections.Generic;

namespace Concesionarios.Core
{
    public class Marca : BaseEntity
    {
        public string Nombre { get; set; }
        public virtual IEnumerable<Coche> Coches { get; set; }
    }
}
