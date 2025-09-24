using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1Emergency2025.Shared.DTO
{
    public class EventoListadoDTO 
    {
        public int Id { get; set; }
        public string Evento { get; set; } = string.Empty;
        public List<PacienteDTO> Pacientes { get; set; } = new();
        public List<UsuarioDTO> Usuarios { get; set; } = new();
        public List<LugarHechoDTO> Lugares { get; set; } = new();
    }
}
