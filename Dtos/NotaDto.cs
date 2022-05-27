using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetAPI.Dtos
{
    public class NotaDto
    {
        [Required]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe ser mayor a {1}")]
        public string Titulo { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "El campo {0} debe tener como minimo {1} caracteres")]
        public string Cuerpo { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class ObtenerDto
    {

    }
}
