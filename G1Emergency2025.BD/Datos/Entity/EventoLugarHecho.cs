using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency.BD.Datos.Entity
{
    public class EventoLugarHecho
    {
        public int LugarHechoId { get; set; }
        public LugarHecho? LugarHecho { get; set; }

        public int EventoId { get; set; }
        public Evento? Eventos { get; set; }
    }
}
