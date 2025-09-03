using G1Emergency2025.BD.Datos;
using G1Emergency2025.BD.Datos.Entity;
using G1Emergency2025.Repositorio.Repositorios;
using G1Emergency2025.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/DiagPresuntivo")]
    public class DiagPresuntivoController : ControllerBase
    {
        private readonly IDiagPresuntivoRepositorio repositorio;

        public DiagPresuntivoController(IDiagPresuntivoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<DiagPresuntivo>>> GetList()
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
        //[HttpGet]
        //public async Task<ActionResult<List<DiagPresuntivoDTO>>> ListadoDiagPresuntivo()
        //{
        //    var lista = await repositorio.SelectListaDiagnosticos();
        //    if (lista == null)
        //    {
        //        return NotFound("No se encontro la lista, VERIFICAR.");
        //    }
        //    if (lista.Count == 0)
        //    {
        //        return Ok("No existen items en la lista en este momento");
        //    }

        //    return Ok(lista);
        //}

        [HttpGet("Id/{id:int}")] 
        public async Task<ActionResult<DiagPresuntivo>> GetById(int id)
        {
            var tipoProvincia = await repositorio.SelectById(id);
            if (tipoProvincia is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }

            return Ok(tipoProvincia);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(DiagPresuntivo diagPresuntivo)
        {
            try
            {
                var id = await repositorio.Insert(diagPresuntivo);
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al crear el nuevo registro: {e.Message}");
            }
        }

        [HttpPut("{id:int}")]  
        public async Task<ActionResult> Put(int id, DiagPresuntivo DTO)
        {
            var resultado = await repositorio.Update(id, DTO);
            if (!resultado)
            {
                return BadRequest("Datos no validos");
            }
            return Ok($"El registro con el id: {id} fue actualizado correctamente.");
        }

        [HttpDelete("{id:int}")] 
        public async Task<ActionResult> Delete(int id, DiagPresuntivo diagPresuntivo)
        {
            var resultado = await repositorio.Delete(id, diagPresuntivo);
            if (!resultado)
            {
                return BadRequest("Datos no validos");
            }
            return Ok($"El registro con el id: {id} fue eliminado correctamente.");
        }
    }
}
