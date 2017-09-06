using Concesionarios.Core.Common;
using Concesionarios.Core.Enum;
using System;

namespace Concesionarios.Core
{
    public class Auditoria : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public Modelo Modelo { get; set; }
        public Accion Accion { get; set; }
        public virtual Coche Coche { get; set; }
        public virtual Concesionario Concesionario { get; set; }
    }
}
