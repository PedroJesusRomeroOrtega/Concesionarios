using Concesionarios.Core.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concesionarios.Core
{
    public class Coche : BaseEntity
    {
        public string Matricula { get; set; }

        [Range(0, int.MaxValue)]
        public int Kilometros { get; set; }

        [Display(Name = "Concesionario")]
        [Required]
        public int IdConcesionario { get; set; }

        [ForeignKey("IdConcesionario")]
        public virtual Concesionario Concesionario { get; set; }

        [Display(Name = "Marca")]
        [Required]
        public int IdMarca { get; set; }

        [ForeignKey("IdMarca")]
        public virtual Marca Marca { get; set; }

    }
}
