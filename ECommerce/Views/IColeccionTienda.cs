using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Views
{
    public interface IColeccionTienda
    {
        Task InsertarTienda(Tiendas tienda);
        Task ActualizarTienda(Tiendas tienda);
        Task EliminarTienda(string id);
        Task<List<Tiendas>> TomarTiendas();
        Task<Tiendas> TomarTiendasId(string id);
    }
}
