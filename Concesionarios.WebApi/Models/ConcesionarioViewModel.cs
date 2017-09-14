using System.ComponentModel.DataAnnotations;

namespace Concesionarios.WebApi.Models
{
    public class ConcesionarioViewModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "El campo Nombre ha excedido su longitud")]
        public string Nombre { get; set; }

        [MaxLength(300, ErrorMessage = "El campo Dirección ha excedido su longitud")]
        public string Direccion { get; set; }
    }
}