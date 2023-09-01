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
    public class ProductosController : Controller
    {
        private IColeccionProducto db = new ColeccionProducto();
        [HttpGet]
        public async Task<IActionResult> TomarCategorias()
        {
            return Ok(await db.TomarProductos());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> TomarDetallesProductos(string id)
        {
            return Ok(await db.TomarProductosId(id));
        }
        [HttpPost]
        public async Task<IActionResult> CrearProducto([FromBody] Productos producto)
        {
            if (producto == null)
                return BadRequest();
            
            if (producto.Nombre == string.Empty)
            {
                ModelState.AddModelError("nombre", "El producto no debe estar vacio");
            }
            await db.InsertarProducto(producto);
            return Created("Created", true);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProducto([FromBody] Productos producto, string id)
        {
            if (producto == null)
                return BadRequest();
            if (producto.Nombre == string.Empty)
            {
                ModelState.AddModelError("nombre", "El producto no debe estar vacio");
            }
            producto.id = new MongoDB.Bson.ObjectId(id);
            await db.ActualizarProducto(producto);
            return Created("Created", true);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProducto(string id)
        {
            await db.EliminarProducto(id);
            return NoContent();
        }
    }
}
