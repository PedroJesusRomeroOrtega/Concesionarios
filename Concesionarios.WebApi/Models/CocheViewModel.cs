using System.ComponentModel.DataAnnotations;

namespace Concesionarios.WebApi.Models
{
    public class CocheViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10, ErrorMessage = "El campo matrícula ha excedido su longitud")]
        [Required]
        public string Matricula { get; set; }

        [Range(0, int.MaxValue)]
        public int Kilometros { get; set; }

        [Required]
        public int IdConcesionario { get; set; }

        [Required]
        public int IdMarca { get; set; }

    }
}