using G1Emergency2025.BD.Datos;
using G1Emergency2025.BD.Datos.Entity;
using G1Emergency2025.Repositorio.Repositorios;
using G1Emergency2025.Shared.DTO;
using G1Emergency2025.Shared.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/evento")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepositorio repositorio;
        public EventoController(IEventoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        //[HttpGet("existe/{Codigo}")]
        //public async Task<ActionResult<bool>> ExisteCodigo(string codigo)
        //{
        //    try
        //    {
        //        bool existe = await repositorio.ExistePredi(x => x.Codigo == codigo);
        //        return Ok(existe);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Error al verificar el código: {ex.Message}");
        //    }
        //}
        [HttpGet]
        public async Task<ActionResult<List<Evento>>> GetList()
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
        public async Task<ActionResult<EventoDTO>> GetById(int id)
        {
            var tipoProvincia = await repositorio.SelectById(id);
            if (tipoProvincia is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }

            return Ok(tipoProvincia);
        }

        [HttpGet("Codigo/{cod}")]
        public async Task<ActionResult<EventoDTO>> GetByCod(string cod)
        {
            var tipoProvincia = await repositorio.SelectByCod(cod);
            if (tipoProvincia is null)
            {
                return NotFound($"No existe el registro con el código: {cod}.");
            }

            return Ok(tipoProvincia);
        }

        [HttpGet("ListaEvento")]
        public async Task<IActionResult> GetListaEvento()
        {
            //var eventos = await repositorio.SelectListaEvento();
            //return Ok(eventos);
            var lista = await repositorio.SelectListaEvento();
            if (lista == null || !lista.Any())
                return NotFound("No hay eventos registrados.");

            return Ok(lista);
        }

        [HttpGet("ListaEventoReciente")]
        public async Task<IActionResult> GetListaEventoReciente()
        {
            var eventos = await repositorio.SelectListaEventoReciente();
            return Ok(eventos);
        }

        [HttpGet("{id}/ListaEventosPorId")]  //api/Pedido/
        public async Task<ActionResult<List<EventoListadoDTO>>> ListaDetallePedidoPorId(int id)
        {
            var lista = await repositorio.SelectListaPorId(id);
            if (lista == null)
            {
                return NotFound($"No se encontro elementos en la lista con el código: {id}.");
            }
            return Ok(lista);
        }



        //[HttpPost]
        //public async Task<IActionResult> PostEvento([FromBody] EventoDTO dto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var id = await repositorio.InsertarEvento(dto);
        //    return CreatedAtAction(nameof(GetById), new { id }, new { id });
        //}
        [HttpPost]
        public async Task<IActionResult> PostEvento([FromBody] EventoDTO dto)
        {
            try
            {
                int id = await repositorio.InsertarEvento(dto);
                return Ok(id);
            }
            catch (ApplicationException ex)
            {
                // Esto devuelve el mensaje controlado al cliente
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                // Errores no esperados
                return StatusCode(500, new { mensaje = "Error interno del servidor", detalle = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, EventoDTO DTO)
        {
            var entidad = new Evento
            {
                Id = id,
                Codigo = DTO.Codigo,
                colorEvento = DTO.colorEvento,
                Domicilio = DTO.Domicilio,
                Telefono = DTO.Telefono,
                FechaHora = DTO.FechaHora,
                CausaId = DTO.CausaId,
                TipoEstadoId = DTO.TipoEstadoId
            };

            var resultado = await repositorio.Update(id, entidad);

            if (!resultado)
            {
                return BadRequest("Datos no válidos");
            }

            return Ok($"El registro con el id: {id} fue actualizado correctamente.");
        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEvento(int id, EventoDTO dto)
        //{
        //    var resultado = await Repositorio.UpdateEvento(id, dto);
        //    if (!resultado)
        //        return NotFound();

        //    return NoContent(); 
        //}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await repositorio.DeleteEvento(id);
            if (!eliminado)
                return NotFound();

            return NoContent();
        }
        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var resultado = await repositorio.Delete(id);
        //    if (!resultado)
        //    {
        //        return BadRequest("Datos no validos");
        //    }
        //    return Ok($"El registro con el id: {id} fue eliminado correctamente.");
        //}
    }
}
