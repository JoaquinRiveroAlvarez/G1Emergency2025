using G1Emergency2025.BD.Datos.Entity;

namespace G1Emergency2025.Repositorio.Repositorios
{
    public interface ITipoTripulanteRepositorio : IRepositorio<TipoTripulante>
    {
        Task<TipoTripulante?> SelectByCod(string cod);
    }
}