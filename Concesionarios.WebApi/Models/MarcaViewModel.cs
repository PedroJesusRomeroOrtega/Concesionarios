using System.ComponentModel.DataAnnotations;

namespace Concesionarios.WebApi.Models
{
    public class MarcaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}