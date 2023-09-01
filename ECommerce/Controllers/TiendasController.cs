using ECommerce.Models;
using ECommerce.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendasController : Controller
    {
        private IColeccionTienda db = new ColeccionTienda();
        [HttpGet]
        public async Task<IActionResult> TomarTiendas()
        {
            return Ok(await db.TomarTiendas());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> TomarDetallesTiendas(string id)
        {
            return Ok(await db.TomarTiendasId(id));
        }
        [HttpPost]
        public async Task<IActionResult> CrearTienda([FromBody] Tiendas tienda)
        {
            if (tienda == null)
                return BadRequest();
            if (tienda.Nombre == string.Empty)
            {
                ModelState.AddModelError("nombre", "La tienda no debe estar vacia");
            }
            await db.InsertarTienda(tienda);
            return Created("Created", true);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTienda([FromBody] Tiendas tienda, string id)
        {
            if (tienda == null)
                return BadRequest();
            if (tienda.Nombre == string.Empty)
            {
                ModelState.AddModelError("nombre", "La tienda no debe estar vacia");
            }
            tienda.id = new MongoDB.Bson.ObjectId(id);
            await db.ActualizarTienda(tienda);
            return Created("Created", true);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTienda(string id)
        {
            await db.EliminarTienda(id);
            return NoContent();
        }
    }
}
