using G1Emergency2025.BD.Datos;
using G1Emergency2025.BD.Datos.Entity;
using G1Emergency2025.Repositorio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/Rol")]
    public class RolController : ControllerBase
    {
        private readonly IRolRepositorio repositorio;
        public RolController(IRolRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rol>>> GetList()
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
        public async Task<ActionResult<Rol>> GetById(int id)
        {
            var Rol = await repositorio.SelectById(id);
            if (Rol is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }

            return Ok(Rol);
        }

        [HttpGet("Codigo/{cod}")]
        public async Task<ActionResult<Rol>> GetByCod(string cod)
        {
            var rol = await repositorio.SelectByCod(cod);
            if (rol is null)
            {
                return NotFound($"No existe el registro con el código: {cod}.");
            }

            return Ok(rol);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Rol rol)
        {

            try
            {
                var id = await repositorio.Insert(rol);
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al crear el nuevo registro: {e.Message}");
            }

        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Rol DTO)
        {
            var resultado = await repositorio.Update(id, DTO);
            if (!resultado)
            {
                return BadRequest("Datos no validos");
            }
            return Ok($"El registro con el id: {id} fue actualizado correctamente.");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id, Rol rol)
        {
            var resultado = await repositorio.Delete(id, rol);
            if (!resultado)
            {
                return BadRequest("Datos no validos");
            }
            return Ok($"El registro con el id: {id} fue eliminado correctamente.");
        }
    }
}
