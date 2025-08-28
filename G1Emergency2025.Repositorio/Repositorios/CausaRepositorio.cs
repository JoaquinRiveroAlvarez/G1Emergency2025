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
    public class CausaRepositorio : Repositorio<Causa>, ICausaRepositorio
    {
        private readonly AppDbContext context;

        public CausaRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<Causa?> SelectByCod(string cod)
        {
            return await context.Set<Causa>().FirstOrDefaultAsync(x => x.Codigo == cod);
        }
    }
}
