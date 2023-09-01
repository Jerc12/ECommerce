using ECommerce.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Views
{
    public class ColeccionProducto : IColeccionProducto
    {
        internal ConexionMongoDB _conexion = new ConexionMongoDB();
        private IMongoCollection<Productos> Coleccion;
        public ColeccionProducto()
        {
            Coleccion = _conexion.db.GetCollection<Productos>("Productos");
        }

        public async Task ActualizarProducto(Productos producto)
        {
            var filtro = Builders<Productos>.Filter.Eq(s => s.id, producto.id);
            await Coleccion.ReplaceOneAsync(filtro, producto);
        }

        public async Task EliminarProducto(string id)
        {
            var filtro = Builders<Productos>.Filter.Eq(s => s.id, new ObjectId(id));
            await Coleccion.DeleteOneAsync(filtro);
        }

        public async Task InsertarProducto(Productos producto)
        {
            await Coleccion.InsertOneAsync(producto);
        }

        public async Task<List<Productos>> TomarProductos()
        {
            return await Coleccion.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Productos> TomarProductosId(string id)
        {
            return await Coleccion.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }
    }
}
