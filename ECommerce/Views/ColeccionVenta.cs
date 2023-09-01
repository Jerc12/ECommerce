using ECommerce.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Views
{
    public class ColeccionVenta : IColeccionVenta
    {
        internal ConexionMongoDB _conexion = new ConexionMongoDB();
        private IMongoCollection<Ventas> Coleccion;
        public ColeccionVenta()
        {
            Coleccion = _conexion.db.GetCollection<Ventas>("Ventas");
        }
        public async Task ActualizarVenta(Ventas venta)
        {
            var filtro = Builders<Ventas>.Filter.Eq(s => s.id, venta.id);
            await Coleccion.ReplaceOneAsync(filtro, venta);
        }

        public async Task EliminarVenta(string id)
        {
            var filtro = Builders<Ventas>.Filter.Eq(s => s.id, new ObjectId(id));
            await Coleccion.DeleteOneAsync(filtro);
        }

        public async Task InsertarVenta(Ventas venta)
        {
            await Coleccion.InsertOneAsync(venta);
        }

        public async Task<List<Ventas>> TomarVentas()
        {
            return await Coleccion.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Ventas> TomarVentasId(string id)
        {
            return await Coleccion.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }
    }
}
