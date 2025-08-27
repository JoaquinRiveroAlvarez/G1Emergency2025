using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1Emergency2025.BD.Datos
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }
        public string Observacion { get; set; } = string.Empty;
    }
}
