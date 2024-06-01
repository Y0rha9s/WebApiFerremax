using System.ComponentModel.DataAnnotations;
using WebApiFerremax.Validaciones;

namespace WebApiFerremax.Entities
{
    public class Herramienta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

    }
}
