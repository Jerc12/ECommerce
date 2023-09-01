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
    public class VentasController : Controller
    {
        private IColeccionVenta db = new ColeccionVenta();
        [HttpGet]
        public async Task<IActionResult> TomarVentas()
        {
            return Ok(await db.TomarVentas());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> TomarDetallesVentas(string id)
        {
            return Ok(await db.TomarVentasId(id));
        }
        [HttpPost]
        public async Task<IActionResult> CrearVenta([FromBody] Ventas venta)
        {
            if (venta == null)
                return BadRequest();
            if (venta.CantProducto == 0)
            {
                ModelState.AddModelError("CantProducto", "La venta no debe estar vacia");
            }
            await db.InsertarVenta(venta);
            return Created("Created", true);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarVenta([FromBody] Ventas venta, string id)
        {
            if (venta == null)
                return BadRequest();
            if (venta.CantProducto == 0)
            {
                ModelState.AddModelError("CantProducto", "La venta no debe estar vacia");
            }
            venta.id = new MongoDB.Bson.ObjectId(id);
            await db.ActualizarVenta(venta);
            return Created("Created", true);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarVenta(string id)
        {
            await db.EliminarVenta(id);
            return NoContent();
        }
    }
}
