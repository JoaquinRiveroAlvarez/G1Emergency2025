using G1Emergency2025.Shared.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1Emergency2025.Shared.DTO
{
    public class EventoListadoDTO 
    {
        public int Id { get; set; }
        public required string Codigo { get; set; }
        public required ColorEvento colorEvento { get; set; }
        public string Domicilio { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public required DateTime FechaHora { get; set; } = DateTime.Now;
        public string Evento { get; set; } = string.Empty;
        public List<PacienteResumenDTO> Pacientes { get; set; } = new();
        public List<UsuarioResumenDTO> Usuarios { get; set; } = new();
        public List<LugarHechoResumenDTO> Lugares { get; set; } = new();
    }
}
