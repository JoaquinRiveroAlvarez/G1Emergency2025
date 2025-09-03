using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1Emergency2025.Shared.DTO
{
    public class DiagPresuntivoDTO : EntityBaseDTO
    {
        public string PosDiagnostico { get; set; } = string.Empty;
        public int PacienteId { get; set; }
    }
}
