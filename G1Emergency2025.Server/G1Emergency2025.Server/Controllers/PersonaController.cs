using G1Emergency2025.BD.Datos;
using G1Emergency2025.BD.Datos.Entity;
using G1Emergency2025.Repositorio.IRepositorios;
using G1Emergency2025.Repositorio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/Persona")]
    public class PersonaController(IPersonaRepositorio repositorio) : ControllerBase
    {
      

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> GetList()
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
        public async Task<ActionResult<Persona>> GetById(int id)
        {
            var persona = await repositorio.SelectById(id);
            if (persona is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }

            return Ok(persona);
        }

        [HttpGet("DNI/{dni}")]
        public async Task<ActionResult<Persona>> GetByDni(string dni)
        {
            var persona = await repositorio.SelectByDni(dni);
            if (persona is null)
            {
                return NotFound($"No existe el registro con el código: {dni}.");
            }

            return Ok(persona);
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(Persona persona)
        {

            try
            {
                var id = await repositorio.Insert(persona);
                return Ok(id);
               
            }
            catch (Exception e)
            {
                return BadRequest($"Error al crear el nuevo registro: {e.Message}");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Persona DTO)
        {
            var resultado = await repositorio.Update(id, DTO);
            if (!resultado)
            {
                return BadRequest("Datos no validos");
            }
            return Ok($"El registro con el id: {id} fue actualizado correctamente.");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id, Persona persona)
        {
            var resultado = await repositorio.Delete(id, persona);
            if (!resultado)
            {
                return BadRequest("Datos no validos");
            }
            return Ok($"El registro con el id: {id} fue eliminado correctamente.");
        }
    }
}
