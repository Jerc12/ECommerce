using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Views
{
    public interface IColeccionUsuario
    {
        Task InsertarUsuario(Usuarios usuario);
        Task ActualizarUsuario(Usuarios usuario);
        Task EliminarUsuario(string id);
        Task<List<Usuarios>> TomarUsuarios();
        Task<Usuarios> TomarUsuariosId(string id);
    }
}
