using G1Emergency2025.BD.Datos;
using G1Emergency2025.BD.Datos.Entity;
using G1Emergency2025.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace G1Emergency2025.Repositorio.Repositorios
{
    public class EventoRepositorio : Repositorio<Evento>, IEventoRepositorio
    {
        private readonly AppDbContext context;

        public EventoRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<Evento?> SelectByCod(string cod)
        {
            return await context.Set<Evento>().FirstOrDefaultAsync(x => x.Codigo == cod);
        }
        public async Task<List<EventoListadoDTO>> SelectListaEvento()
        {
            var lista = await context.Eventos
                                    .Select(p => new EventoListadoDTO
                                    {
                                        Id = p.Id,
                                        Evento = $" Código: {p.Codigo} - Prioridad(Color) del Evento: {p.colorEvento} - Domicilio: {p.Domicilio} - Telefono: {p.Telefono} - Fecha y Hora: {p.FechaHora} - Código Causa: {p.Causa!.Codigo} - Estado: {p.TipoEstados!.Tipo}"
                                    })
                                    .ToListAsync();
            return lista;
        }
    }
}
