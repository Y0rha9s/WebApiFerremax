using System.ComponentModel.DataAnnotations;
using WebApiFerremax.Entities;
using WebApiFerremax.Validaciones;

namespace WebApiFerremax.DTOs
{
    public class HerramientaManualCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        [PrimeraLetraMayuscula]
        public string Marca { get; set; }

        public int Precio { get; set; }

        
    }
}
