using ECommerce.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Views
{
    public class ColeccionCategoria : IColeccionCategoria
    {
        internal ConexionMongoDB _conexion = new ConexionMongoDB();
        private IMongoCollection<Categorias> Coleccion;
        public ColeccionCategoria()
        {
            Coleccion = _conexion.db.GetCollection<Categorias>("Categorias");
        }
        public async Task ActualizarCategoria(Categorias categoria)
        {
            var filtro = Builders<Categorias>.Filter.Eq(s => s.id, categoria.id);
            await Coleccion.ReplaceOneAsync(filtro,categoria);
        }

        public async Task EliminarCategoria(string id)
        {
            var filtro = Builders<Categorias>.Filter.Eq(s => s.id, new ObjectId(id));
            await Coleccion.DeleteOneAsync(filtro);
        }

        public async Task InsertarCategoria(Categorias categoria)
        {
            await Coleccion.InsertOneAsync(categoria);
        }

        public async Task<List<Categorias>> TomarCategorias()
        {
            return await Coleccion.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Categorias> TomarCategoriasId(string id)
        {
            return await Coleccion.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }
    }
}
