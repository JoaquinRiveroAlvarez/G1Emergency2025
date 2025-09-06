using G1Emergency2025.BD.Datos;
using G1Emergency2025.BD.Datos.Entity;
using G1Emergency2025.Repositorio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace G1Emergency2025.Server.Controllers
{
    [ApiController]
    [Route("api/Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IRepositorio<Usuario> repositorio;
        public UsuarioController(AppDbContext context,
                               IRepositorio<Usuario> repositorio)
        {
            this.context = context;
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetList()
        {
            var lista = await repositorio.Select();
            if (lista == null)
            {
                return NotFound("No se encontro la lista, VERIFICAR.");
            }
            if (lista.Count == 0)
            {
                return Ok("No existen items en la lista en este momento");
            }

            return Ok(lista);
        }

        [HttpGet("Id/{id:int}")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            var Usuario = await repositorio.SelectById(id);
            if (Usuario is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }

            return Ok(Usuario);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Usuario DTO)
        {
            try
            {
                await repositorio.Insert(DTO);
                await context.SaveChangesAsync();
                return Ok(DTO.Id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al crear el nuevo registro: {e.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Usuario DTO)
        {
            var resultado = await repositorio.Update(id, DTO);
            if (!resultado)
            {
                return BadRequest("Datos no validos");
            }
            return Ok($"El registro con el id: {id} fue actualizado correctamente.");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id, Usuario usuario)
        {

            var resultado = await repositorio.Delete(id, usuario);
            if (!resultado)
            {
                return BadRequest("Datos no validos");
            }
            return Ok($"El registro con el id: {id} fue eliminado correctamente.");
        }
    }
}
