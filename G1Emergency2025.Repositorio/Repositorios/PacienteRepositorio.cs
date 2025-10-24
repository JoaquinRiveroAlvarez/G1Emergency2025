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
    public class PacienteRepositorio : Repositorio<Paciente>, IPacienteRepositorio
    {
        private readonly AppDbContext context;

        public PacienteRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<Paciente?> SelectByObraSocial(string cod)
        {
            return await context.Set<Paciente>().FirstOrDefaultAsync(x => x.ObraSocial == cod);
        }
        public async Task<List<PacienteListadoDTO>> SelectListaPaciente()
        {
            var lista = await context.Pacientes
                                    .Select(p => new PacienteListadoDTO
                                    {
                                        Id = p.Id,
                                        Paciente = $" Obra Social: {p.ObraSocial} - Id Persona: {p.PersonaId} - Nombre y Apellido: {p.Personas!.Nombre} - DNI: {p.Personas!.DNI}"
                                    })
                                    .ToListAsync();
            return lista;
        }
        public async Task AsociarEvento(int pacienteId, int eventoId)
        {
            var rel = new PacienteEvento
            {
                PacienteId = pacienteId,
                EventoId = eventoId
            };

            context.PacienteEventos.Add(rel);
            await context.SaveChangesAsync();
        }
        public async Task<int> CrearPacienteConPersona(Persona persona, Paciente paciente)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                await context.Personas.AddAsync(persona);
                await context.SaveChangesAsync();

                paciente.PersonaId = persona.Id;
                await context.Pacientes.AddAsync(paciente);
                await context.SaveChangesAsync();

                await transaction.CommitAsync();
                return paciente.Id;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
