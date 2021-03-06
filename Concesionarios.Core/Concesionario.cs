﻿using Concesionarios.Core.Common;
using System.Collections.Generic;

namespace Concesionarios.Core
{
    public class Concesionario : BaseEntity
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public virtual ICollection<Coche> Coches { get; set; }
    }
}
