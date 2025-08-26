using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency.BD.Datos.Entity
{
    public class MovilEvento
    {
        public int MovilId { get; set; }
        public Movil? Movils { get; set; }

        public int EventoId { get; set; }
        public Evento? Eventos { get; set; }
    }
}
