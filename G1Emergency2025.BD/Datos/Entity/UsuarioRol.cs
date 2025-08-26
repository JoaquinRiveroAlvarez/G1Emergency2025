using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency.BD.Datos.Entity
{
    public class UsuarioRol
    {
        public int UsuarioId { get; set; }
        public Usuario? Usuarios { get; set; }

        public int RolId { get; set; }
        public Rol? Rols { get; set; }
    }
}
