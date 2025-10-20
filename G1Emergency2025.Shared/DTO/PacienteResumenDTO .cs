using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1Emergency2025.Shared.DTO
{
    public class PacienteResumenDTO 
    {
        public int Id { get; set; }
        public required string ObraSocial { get; set; }

        //public PersonaDTO? Persona { get; set; }
    }
}
