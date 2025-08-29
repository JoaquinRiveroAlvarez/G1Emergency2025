using G1Emergency2025.BD.Datos;
using G1Emergency2025.BD.Datos.Entity;
using G1Emergency2025.Repositorio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/TipoMovil")]
    public class TipoMovilController : ControllerBase
    {
        private readonly ITipoMovilRepositorio repositorio;
        public TipoMovilController(ITipoMovilRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoMovil>>> GetList()
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
        public async Task<ActionResult<TipoMovil>> GetById(int id)
        {
            var tipoProvincia = await repositorio.SelectById(id);
            if (tipoProvincia is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }

            return Ok(tipoProvincia);
        }

        [HttpGet("Codigo/{cod}")]
        public async Task<ActionResult<TipoMovil>> GetByCod(string cod)
        {
            var tipoProvincia = await repositorio.SelectByCod(cod);
            if (tipoProvincia is null)
            {
                return NotFound($"No existe el registro con el código: {cod}.");
            }

            return Ok(tipoProvincia);
        }

        [HttpGet("Tipo/{tipo}")]
        public async Task<ActionResult<TipoMovil>> GetByTipo(string tipo)
        {
            var tipoProvincia = await repositorio.SelectByCod(tipo);
            if (tipoProvincia is null)
            {
                return NotFound($"No existe el registro con el código: {tipo}.");
            }

            return Ok(tipoProvincia);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(TipoMovil causa)
        {

            try
            {
                var id = await repositorio.Insert(causa);
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al crear el nuevo registro: {e.Message}");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, TipoMovil DTO)
        {
            var resultado = await repositorio.Update(id, DTO);
            if (!resultado)
            {
                return BadRequest("Datos no validos");
            }
            return Ok($"El registro con el id: {id} fue actualizado correctamente.");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id, TipoMovil causa)
        {
            var resultado = await repositorio.Delete(id, causa);
            if (!resultado)
            {
                return BadRequest("Datos no validos");
            }
            return Ok($"El registro con el id: {id} fue eliminado correctamente.");
        }
    }
}
