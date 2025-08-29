using G1Emergency2025.BD.Datos;
using G1Emergency2025.BD.Datos.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace G1Emergency2025.Repositorio.Repositorios
{
    public class TripulanteRepositorio : Repositorio<Tripulante>, ITripulanteRepositorio
    {
        private readonly AppDbContext context;

        public TripulanteRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
