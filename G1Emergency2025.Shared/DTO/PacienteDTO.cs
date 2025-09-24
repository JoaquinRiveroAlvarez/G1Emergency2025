using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1Emergency2025.Shared.DTO
{
    public class PacienteDTO 
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La obra social es obligatoria")]
        public required string ObraSocial { get; set; }
        public int PersonaId { get; set; }
    }
}
