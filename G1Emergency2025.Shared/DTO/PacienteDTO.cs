using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1Emergency2025.Shared.DTO
{
    public class PacienteDTO : EntityBaseDTO
    {
        public string ObraSocial { get; set; } = string.Empty;

        public int PersonaId { get; set; }
    }
}
