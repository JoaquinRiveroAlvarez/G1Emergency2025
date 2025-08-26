using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using G1Emergency2025.BD.Datos;
using G1Emergency2025.BD.Datos.Entity;

namespace Proyecto2025.Server.Controllers
{
    [ApiController]
    [Route("api/Causa")]
    public class CausaController : ControllerBase
    {
        private readonly AppDbContext context;

        public CausaController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet] //api/TipoProvincia
        public async Task<ActionResult<List<Causa>>> GetList()
        {
            var lista = await context.Causas.ToListAsync();
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

        [HttpGet("Id/{id:int}")]  //api/TipoProvincia/5
        public async Task<ActionResult<Causa>> GetById(int id)
        {
            var tipoProvincia = await context.Causas.FirstOrDefaultAsync(x => x.Id == id);
            if (tipoProvincia is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }

            return Ok(tipoProvincia);
        }

        [HttpGet("Codigo/{cod}")]  //api/TipoProvincia/PRU
        public async Task<ActionResult<Causa>> GetByCod(string cod)
        {
            var tipoProvincia = await context.Causas.FirstOrDefaultAsync(x => x.Codigo == cod);
            if (tipoProvincia is null)
            {
                return NotFound($"No existe el registro con el código: {cod}.");
            }

            return Ok(tipoProvincia);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Causa DTO)
        {
            try
            {                
                await context.Causas.AddAsync(DTO);
                await context.SaveChangesAsync();
                return Ok(DTO.Id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al crear el nuevo registro: {e.Message}");
            }
        }

        [HttpPut("{id:int}")]  // api/TipoProvincia/6
        public async Task<ActionResult> Put(int id, Causa DTO)
        {
            if (id != DTO.Id)
            {
                return BadRequest("Datos no validos.");
            }
            var existe = await context.Causas.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }
            context.Update(DTO);
            await context.SaveChangesAsync();
            return Ok($"El registro con el id: {id} fue actualizado correctamente.");
        }

        [HttpDelete("{id:int}")]  // api/TipoProvincia/6
        public async Task<ActionResult> Delete(int id)
        {
            var tipoProvincia = await context.Causas.FirstOrDefaultAsync(x => x.Id == id);
            if (tipoProvincia is null)
            {
                return NotFound($"No existe el registro con el id: {id}.");
            }
            context.Causas.Remove(tipoProvincia);
            await context.SaveChangesAsync();
            return Ok($"El registro con el id: {id} fue eliminado correctamente.");
        }

        //[HttpPut("{cod}")]  // api/TipoProvincia/6
        //public async Task<ActionResult> PutByCod(string cod, Producto DTO)
        //{
        //    if (cod != DTO.CodProducto)
        //    {
        //        return BadRequest("Datos no validos.");
        //    }
        //    var existe = await context.Productos.AnyAsync(x => x.CodProducto == cod);
        //    if (!existe)
        //    {
        //        return NotFound($"No existe el tipo de provincia con el id: {cod}.");
        //    }
        //    context.Update(DTO);
        //    await context.SaveChangesAsync();
        //    return Ok($"Tipo de provincia con el id: {cod} actualizado correctamente.");
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTipoProvincia(int id)
        //{
        //    var tipoProvincia = await context.TipoProvincias.FindAsync(id);

        //    if (tipoProvincia == null)
        //        return NotFound();

        //    tipoProvincia.EstadoRegistro = EnumEstadoRegistro.inactivo;

        //    context.TipoProvincias.Update(tipoProvincia);
        //    await context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}
