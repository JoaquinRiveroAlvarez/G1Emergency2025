using G1Emergency2025.BD.Datos.Entity;

namespace G1Emergency2025.Repositorio.Repositorios
{
    public interface ITipoMovilRepositorio : IRepositorio<TipoMovil>
    {
        Task<TipoMovil?> SelectByCod(string cod);
        Task<TipoMovil?> SelectByTipo(string tipo);
    }
}