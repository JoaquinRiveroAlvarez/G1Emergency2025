using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency.BD.Datos.Entity
{
    public class TipoEstadoEvento
    {
        public int TipoEstadoId { get; set; }
        public TipoEstado? TipoEstados { get; set; }

        public int EventoId { get; set; }
        public Evento? Eventos { get; set; }
    }
}
