using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1Emergency2025.Shared.DTO
{
    public class CausaDTO : EntityBaseDTO
    {
        public string Codigo { get; set; } = string.Empty;
        public string posibleCausa { get; set; } = string.Empty;
    }
}
