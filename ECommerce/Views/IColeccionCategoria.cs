using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Views
{
    public interface IColeccionCategoria
    {
        Task InsertarCategoria(Categorias categoria);
        Task ActualizarCategoria(Categorias categoria);
        Task EliminarCategoria(string id);
        Task<List<Categorias>> TomarCategorias();
        Task<Categorias> TomarCategoriasId(string id);

    }
}
