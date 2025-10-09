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
    [Route("api/Evento")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepositorio repositorio;
        public EventoController(IEventoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

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

        [HttpGet("ListaEventos")]
        public async Task<IActionResult> GetListaEvento()
        {
            var eventos = await repositorio.SelectListaEvento();
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
        //REVISAR POST MUCHOS A MUCHOS EN TODAS LAS TABLAS

        [HttpPost]
        public async Task<IActionResult> PostEvento([FromBody] EventoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await repositorio.InsertarEvento(dto);
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        //[HttpPost]
        //public async Task<ActionResult<int>> Post(EventoDTO DTO)
        //{
        //    try
        //    {
        //        Evento entidad = new Evento
        //        {
        //            Codigo = DTO.Codigo,
        //            colorEvento = DTO.colorEvento,
        //            Domicilio = DTO.Domicilio,
        //            Telefono = DTO.Telefono,
        //            FechaHora = DTO.FechaHora,
        //            CausaId = DTO.CausaId,
        //            TipoEstadoId = DTO.TipoEstadoId
        //        };
        //        var id = await repositorio.Insert(entidad);
        //        return Ok(entidad.Id);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest($"Error al crear el nuevo registro: {e.Message}");
        //    }

        //}

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

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resultado = await repositorio.Delete(id);
            if (!resultado)
            {
                return BadRequest("Datos no validos");
            }
            return Ok($"El registro con el id: {id} fue eliminado correctamente.");
        }
    }
}
