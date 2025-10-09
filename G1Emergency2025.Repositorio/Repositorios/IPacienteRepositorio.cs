using G1Emergency2025.BD.Datos.Entity;
using G1Emergency2025.Shared.DTO;

namespace G1Emergency2025.Repositorio.Repositorios
{
    public interface IPacienteRepositorio : IRepositorio<Paciente>
    {
        Task<Paciente?> SelectByObraSocial(string cod);
        Task<List<PacienteListadoDTO>> SelectListaPaciente();
        Task AsociarEvento(int pacienteId, int eventoId);
    }
}