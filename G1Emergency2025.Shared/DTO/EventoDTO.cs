using G1Emergency2025.Shared.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1Emergency2025.Shared.DTO
{
    public class EventoDTO
    {
        [Required(ErrorMessage = "El código es obligatorio")]
        public required string Codigo { get; set; }

        [Required(ErrorMessage = "El Color es obligatorio")]
        public required ColorEvento colorEvento { get; set; }

        [MaxLength(100, ErrorMessage = "La cantidad Maxima de caracteres es 100")]
        public string Domicilio { get; set; } = string.Empty;

        [MaxLength(30, ErrorMessage = "La cantidad Maxima de caracteres es 30")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "La Fecha y Hora es obligatoria")]
        public required DateTime FechaHora { get; set; } = DateTime.Now;

        public int CausaId { get; set; }
        public int TipoEstadoId { get; set; }
        public List<int>? PacienteIds { get; set; } = new();
        public List<int>? UsuarioIds { get; set; } = new();
        public List<int>? LugarHechoIds { get; set; } = new();
    }
}
