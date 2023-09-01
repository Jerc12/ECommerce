using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Views
{
    public interface IColeccionProducto
    {
        Task InsertarProducto(Productos producto);
        Task ActualizarProducto(Productos producto);
        Task EliminarProducto(string id);
        Task<List<Productos>> TomarProductos();
        Task<Productos> TomarProductosId(string id);
    }
}
