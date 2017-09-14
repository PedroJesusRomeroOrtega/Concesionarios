using System.ComponentModel.DataAnnotations;

namespace Concesionarios.WebApi.Models
{
    public class ConcesionarioViewModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El campo Nombre ha excedido su longitud")]
        public string Nombre { get; set; }

        [StringLength(300, ErrorMessage = "El campo Dirección ha excedido su longitud")]
        public string Direccion { get; set; }

        //public ICollection<CocheViewModel> Coches { get; set; }
    }
}