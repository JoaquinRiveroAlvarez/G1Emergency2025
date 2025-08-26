using G1Emergency2025.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1Emergency2025.BD.Datos.Entity
{
    public class TripulacionActual
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La Fecha de entrada es obligatoria")]
        [MaxLength(50, ErrorMessage = "La cantidad Maxima de caracteres es 50")]
        public required DateTime FechaEntrada { get; set; } = DateTime.Now;

        public int TripulanteId { get; set; }
        public Tripulante? Tripulantes { get; set; }

        public int MovilId { get; set; }
        public Movil? Movils { get; set; }

    }
}
