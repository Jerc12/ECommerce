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
    public class UsuariosController : Controller
    {
        private IColeccionUsuario db = new ColeccionUsuario();
        [HttpGet]
        public async Task<IActionResult> TomarUsuarios()
        {
            return Ok(await db.TomarUsuarios());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> TomarDetallesUsuarios(string id)
        {
            return Ok(await db.TomarUsuariosId(id));
        }
        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] Usuarios usuario)
        {
            if (usuario == null)
                return BadRequest();
            if (usuario.Nombre == string.Empty)
            {
                ModelState.AddModelError("nombre", "El usuario no debe estar vacio");
            }
            await db.InsertarUsuario(usuario);
            return Created("Created", true);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario([FromBody] Usuarios usuario, string id)
        {
            if (usuario == null)
                return BadRequest();
            if (usuario.Nombre == string.Empty)
            {
                ModelState.AddModelError("nombre", "El usuario no debe estar vacio");
            }
            usuario.id = new MongoDB.Bson.ObjectId(id);
            await db.ActualizarUsuario(usuario);
            return Created("Created", true);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(string id)
        {
            await db.EliminarUsuario(id);
            return NoContent();
        }
    }
}
