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
                .Include(e => e.PacienteEventos)
                    .ThenInclude(pe => pe.Pacientes)
                .Include(e => e.EventoUsuarios)
                    .ThenInclude(eu => eu.Usuarios)
                .Include(e => e.EventoLugarHechos)
                    .ThenInclude(elh => elh.LugarHecho)
                .Include(e => e.TipoEstados)
                .Select(e => new EventoListadoDTO
                {
                    Id = e.Id,
                    Evento = $" Código: {e.Codigo} - Prioridad(Color) del Evento: {e.colorEvento} - Domicilio: {e.Domicilio} - " +
                              $"Teléfono: {e.Telefono} - " +
                              $"Fecha y Hora: {e.FechaHora} - Código Causa: {e.Causa!.Codigo} - Estado: {e.TipoEstados!.Tipo}",

                    // aquí usamos el DTO de "listado"
                    Pacientes = e.PacienteEventos
                        .Select(pe => new PacienteDTO
                        {
                            Id = pe.PacienteId,
                            ObraSocial = " Obra Social: " +pe.Pacientes.ObraSocial +" DNI: "+ pe.Pacientes!.Personas!.DNI + " Nombre y Apellido: " + pe.Pacientes.Personas.Nombre + "" + pe.Pacientes.Personas.Apellido
                        }).ToList(),

                    Usuarios = e.EventoUsuarios
                        .Select(eu => new UsuarioDTO
                        {
                            Id = eu.UsuarioId,
                            Nombre = " Nombre de Usuario: " + eu.Usuarios!.Nombre + " Contraseña: " + eu.Usuarios.Contrasena + " Id Persona: " +eu.Usuarios!.Personas!.Id
                        }).ToList(),

                    Lugares = e.EventoLugarHechos
                        .Select(elh => new LugarHechoDTO
                        {
                            Id = elh.LugarHecho!.Id,
                            Codigo = " Código: " + elh.LugarHecho.Codigo + " Tipo: " + elh.LugarHecho.Tipo + " Descripción: " + elh.LugarHecho.Descripcion
                        }).ToList()

                }).ToListAsync();

            return lista;
        }


        //public async Task<List<EventoListadoDTO>> SelectListaEvento()
        //{
        //    var lista = await context.Eventos
        //                            .Select(p => new EventoListadoDTO
        //                            {
        //                                Id = p.Id,
        //                                Evento = $" Código: {p.Codigo} - Prioridad(Color) del Evento: {p.colorEvento} - Domicilio: {p.Domicilio} - " +
        //                                $"Telefono: {p.Telefono} - " +
        //                                $"Fecha y Hora: {p.FechaHora} - Código Causa: {p.Causa!.Codigo} - Estado: {p.TipoEstados!.Tipo}"
        //                            })
        //                            .ToListAsync();
        //    return lista;
        //}
    }
}
