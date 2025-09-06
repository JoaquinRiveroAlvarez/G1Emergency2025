using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1Emergency2025.Shared.DTO
{
    public class PersonaDTO : EntityBaseDTO
    {
        public required string Nombre { get; set; }

        public required string Apellido { get; set; }

        public required string DNI { get; set; }

        public string Dirección { get; set; } = string.Empty;

        public required string Sexo { get; set; }   

        public required string Edad { get; set; }


    }
}
