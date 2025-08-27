using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1Emergency2025.BD.Datos.Entity
{
    public class DiagPresuntivo : EntityBase
    {

        [Required(ErrorMessage = "El Diagnostico presuntivo es obligatorio.")]
        [MaxLength(100, ErrorMessage = "La cantidad Maxima de caracteres es 100")]
        public required string PosDiagnostico { get; set; }

        public int PacienteId { get; set; }
        public Paciente? Pacientes { get; set; }
    }
}
