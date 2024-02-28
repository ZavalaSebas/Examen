using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class Distrito
    {
        [Key]
        public int DistritoId { get; set; }

        [Required(ErrorMessage = "El nombre del distrito es obligatorio.")]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
