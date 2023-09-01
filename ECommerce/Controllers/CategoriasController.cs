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
    public class CategoriasController : Controller
    {
        private IColeccionCategoria db = new ColeccionCategoria();
        [HttpGet]
        public async Task<IActionResult> TomarCategorias()
        {
            return Ok(await db.TomarCategorias());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> TomarDetallesCategorias(string id)
        {
            return Ok(await db.TomarCategoriasId(id));
        }
        [HttpPost]
        public async Task<IActionResult> CrearCategoria([FromBody] Categorias categoria)
        {
            if (categoria == null)
                return BadRequest();
            if(categoria.Nombre == string.Empty)
            {
                ModelState.AddModelError("nombre", "La categoria no debe estar vacia");
            }
            await db.InsertarCategoria(categoria);
            return Created("Created", true);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCategoria([FromBody] Categorias categoria, string id)
        {
            if (categoria == null)
                return BadRequest();
            if (categoria.Nombre == string.Empty)
            {
                ModelState.AddModelError("nombre", "La categoria no debe estar vacia");
            }
            categoria.id = new MongoDB.Bson.ObjectId(id);
            await db.ActualizarCategoria(categoria);
            return Created("Created", true);
        }
        [HttpDelete ("{id}")]
        public async Task<IActionResult> EliminarCategoria(string id)
        {
            await db.EliminarCategoria(id);
            return NoContent();
        }
    }
}
