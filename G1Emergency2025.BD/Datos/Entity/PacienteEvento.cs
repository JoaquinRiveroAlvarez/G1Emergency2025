using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency.BD.Datos.Entity
{
    public class PacienteEvento
    {
        public int EventoId { get; set; }
        public required Evento Eventos { get; set; }
        public int PacienteId { get; set; }
        public required Paciente Pacientes { get; set; }
    }
}
