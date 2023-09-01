using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Views
{
    public interface IColeccionVenta
    {
        Task InsertarVenta(Ventas venta);
        Task ActualizarVenta(Ventas venta);
        Task EliminarVenta(string id);
        Task<List<Ventas>> TomarVentas();
        Task<Ventas> TomarVentasId(string id);
    }
}
