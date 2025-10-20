using G1Emergency2025.BD.Datos;
using G1Emergency2025.BD.Datos.Entity;
using G1Emergency2025.Shared.DTO;
using G1Emergency2025.Shared.Enum;
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
        private readonly IPacienteRepositorio pacienteRepo;
        private readonly IUsuarioRepositorio usuarioRepo;
        private readonly ILugarHechoRepositorio lugarHechoRepo;

        public EventoRepositorio(AppDbContext context,
        IPacienteRepositorio pacienteRepo,
        IUsuarioRepositorio usuarioRepo,
        ILugarHechoRepositorio lugarHechoRepo) : base(context)
        {
            this.context = context;
            this.pacienteRepo = pacienteRepo;
            this.usuarioRepo = usuarioRepo;
            this.lugarHechoRepo = lugarHechoRepo;
        }
        public async Task<Evento?> SelectByCod(string cod)
        {
            return await context.Set<Evento>().FirstOrDefaultAsync(x => x.Codigo == cod);
        }

        public async Task<EventoListadoDTO?> SelectListaPorId(int id)
        {
            return await context.Eventos
                .Include(e => e.PacienteEventos)
                    .ThenInclude(pe => pe.Pacientes)
                .Include(e => e.EventoUsuarios)
                    .ThenInclude(eu => eu.Usuarios)
                .Include(e => e.EventoLugarHechos)
                    .ThenInclude(elh => elh.LugarHecho)
                .Include(e => e.TipoEstados)
                .Where(e => e.Id == id)

                .Select(e => new EventoListadoDTO
                {
                    Id = e.Id,
                    Codigo = e.Codigo,
                    colorEvento = e.colorEvento,
                    Domicilio = e.Domicilio,
                    Telefono = e.Telefono,
                    FechaHora = e.FechaHora,

                    Pacientes = e.PacienteEventos
                        .Select(pe => new PacienteResumenDTO
                        {
                            Id = pe.PacienteId,
                            ObraSocial = " Obra Social: " + pe.Pacientes!.ObraSocial + " DNI: " + pe.Pacientes!.Personas!.DNI + " Nombre y Apellido: " + pe.Pacientes.Personas.Nombre + " " + pe.Pacientes.Personas.Apellido
                        }).ToList(),

                    Usuarios = e.EventoUsuarios
                        .Select(eu => new UsuarioResumenDTO
                        {
                            Id = eu.UsuarioId,
                            Nombre = " Nombre de Usuario: " + eu.Usuarios!.Nombre + " DNI: " + eu.Usuarios!.Personas!.DNI,
                            Contrasena = "Contraseña: " + eu.Usuarios.Contrasena
                        }).ToList(),

                    Lugares = e.EventoLugarHechos
                        .Select(elh => new LugarHechoResumenDTO
                        {
                            Id = elh.LugarHecho!.Id,
                            Codigo = " Código: " + elh.LugarHecho.Codigo,
                            Tipo = " Tipo: " + elh.LugarHecho.Tipo,
                            Descripcion = " Descripción: " + elh.LugarHecho.Descripcion
                        }).ToList()
                })
                .FirstOrDefaultAsync();
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
                    Codigo = e.Codigo,
                    colorEvento = e.colorEvento,
                    Domicilio = e.Domicilio,
                    Telefono = e.Telefono,
                    FechaHora = e.FechaHora,
                    //Pacientes = e.PacienteEventos.Select(pe => pe.Paciente.Persona.Nombre).ToList(),
                    //Usuarios = e.EventoUsuarios.Select(eu => eu.Usuario.Nombre).ToList(),
                    //Lugares = e.EventoLugarHechos.Select(elh => elh.LugarHechoResumenDTO.Descripcion).ToList()
                    Pacientes = e.PacienteEventos
                        .Select(pe => new PacienteResumenDTO
                        {
                            Id = pe.PacienteId,
                            ObraSocial = " Obra Social: " + pe.Pacientes!.ObraSocial + " DNI: " + pe.Pacientes!.Personas!.DNI + " Nombre y Apellido: " + pe.Pacientes.Personas.Nombre + " " + pe.Pacientes.Personas.Apellido
                        }).ToList(),

                    Usuarios = e.EventoUsuarios
                        .Select(eu => new UsuarioResumenDTO
                        {
                            Id = eu.UsuarioId,
                            Nombre = " Nombre de Usuario: " + eu.Usuarios!.Nombre + " DNI: " + eu.Usuarios!.Personas!.DNI,
                            Contrasena = "Contraseña: " + eu.Usuarios.Contrasena
                        }).ToList(),

                    Lugares = e.EventoLugarHechos
                        .Select(elh => new LugarHechoResumenDTO
                        {
                            Id = elh.LugarHecho!.Id,
                            Codigo = " Código: " + elh.LugarHecho.Codigo,
                            Tipo = " Tipo: " + elh.LugarHecho.Tipo,
                            Descripcion = " Descripción: " + elh.LugarHecho.Descripcion
                        }).ToList()

                })
                .OrderBy(e => e.FechaHora)
                .ToListAsync();

            return lista;
        }

        public async Task<int> InsertarEvento(EventoDTO dto)
        {
            var evento = new Evento
            {
                Codigo = dto.Codigo,
                colorEvento = dto.colorEvento,
                Domicilio = dto.Domicilio,
                Telefono = dto.Telefono,
                FechaHora = dto.FechaHora,
                CausaId = dto.CausaId,
                TipoEstadoId = dto.TipoEstadoId,
                EstadoRegistro = EnumEstadoRegistro.activo
            };

            context.Eventos.Add(evento);
            await context.SaveChangesAsync();

            // Relaciones
            if (dto.PacienteIds != null)
                foreach (var pid in dto.PacienteIds)
                    await pacienteRepo.AsociarEvento(pid, evento.Id);

            if (dto.UsuarioIds != null)
                foreach (var uid in dto.UsuarioIds)
                    await usuarioRepo.AsociarEvento(uid, evento.Id);

            if (dto.LugarHechoIds != null)
                foreach (var lid in dto.LugarHechoIds)
                    await lugarHechoRepo.AsociarEvento(lid, evento.Id);

            return evento.Id;
        }
        public async Task<bool> DeleteEvento(int id)
        {
            var evento = await context.Eventos
                .Include(e => e.PacienteEventos)
                .Include(e => e.EventoUsuarios)
                .Include(e => e.EventoLugarHechos)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (evento == null)
                return false;

            // Eliminar relaciones N:M manualmente
            context.RemoveRange(evento.PacienteEventos);
            context.RemoveRange(evento.EventoUsuarios);
            context.RemoveRange(evento.EventoLugarHechos);

            // Finalmente eliminar el evento
            context.Eventos.Remove(evento);

            await context.SaveChangesAsync();
            return true;
        }
    }
}
