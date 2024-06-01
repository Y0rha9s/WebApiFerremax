using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApiFerremax.Entities;
using WebApiFerremax.Validaciones;

namespace WebApiFerremax.DTOs
{
    public class HerramientaManualDTO
    {
        public int Id { get; set; }

        public string Marca { get; set; }

        public int Precio { get; set; }
    }
}
