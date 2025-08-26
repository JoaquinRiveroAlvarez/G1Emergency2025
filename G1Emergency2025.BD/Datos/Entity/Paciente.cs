using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency.BD.Datos.Entity
{
    public class Paciente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La obra social es obligatoria")]
        [MaxLength(100, ErrorMessage = "La cantidad Maxima de caracteres es 50")]
        public required string ObraSocial { get; set; }
        public Persona? Persona { get; set; }
        public List<PacienteEvento> PacienteEventos { get; set; } = new ();
  
    }
}
