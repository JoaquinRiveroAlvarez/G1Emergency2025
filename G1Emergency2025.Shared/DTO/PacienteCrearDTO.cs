using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1Emergency2025.Shared.DTO
{
    public class PacienteCrearDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string DNI { get; set; } = string.Empty;
        public string Dirección { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public string Edad { get; set; } = string.Empty;
        public string ObraSocial { get; set; } = string.Empty;
    }
}
