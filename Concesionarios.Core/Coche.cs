using Concesionarios.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace Concesionarios.Core
{
    public class Coche : BaseEntity
    {
        public string Matricula { get; set; }
        [Range(0, int.MaxValue)]
        public int Kilometros { get; set; }
        public virtual Concesionario Concesionario { get; set; }
        public virtual Marca Marca { get; set; }
    }
}
