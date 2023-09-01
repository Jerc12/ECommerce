using ECommerce.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Views
{
    public class ColeccionTienda : IColeccionTienda
    {
        internal ConexionMongoDB _conexion = new ConexionMongoDB();
        private IMongoCollection<Tiendas> Coleccion;
        public ColeccionTienda()
        {
            Coleccion = _conexion.db.GetCollection<Tiendas>("Tiendas");
        }
        public async Task ActualizarTienda(Tiendas tienda)
        {
            var filtro = Builders<Tiendas>.Filter.Eq(s => s.id, tienda.id);
            await Coleccion.ReplaceOneAsync(filtro, tienda);
        }

        public async Task EliminarTienda(string id)
        {
            var filtro = Builders<Tiendas>.Filter.Eq(s => s.id, new ObjectId(id));
            await Coleccion.DeleteOneAsync(filtro);
        }

        public async Task InsertarTienda(Tiendas tienda)
        {
            await Coleccion.InsertOneAsync(tienda);
        }

        public async Task<List<Tiendas>> TomarTiendas()
        {
            return await Coleccion.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Tiendas> TomarTiendasId(string id)
        {
            return await Coleccion.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }
    }
}
