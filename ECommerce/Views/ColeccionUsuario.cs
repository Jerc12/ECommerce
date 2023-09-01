using ECommerce.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Views
{
    public class ColeccionUsuario : IColeccionUsuario
    {
        internal ConexionMongoDB _conexion = new ConexionMongoDB();
        private IMongoCollection<Usuarios> Coleccion;
        public ColeccionUsuario()
        {
            Coleccion = _conexion.db.GetCollection<Usuarios>("Usuarios");
        }
        public async Task ActualizarUsuario(Usuarios usuario)
        {
            var filtro = Builders<Usuarios>.Filter.Eq(s => s.id, usuario.id);
            await Coleccion.ReplaceOneAsync(filtro, usuario);
        }

        public async Task EliminarUsuario(string id)
        {
            var filtro = Builders<Usuarios>.Filter.Eq(s => s.id, new ObjectId(id));
            await Coleccion.DeleteOneAsync(filtro);
        }

        public async Task InsertarUsuario(Usuarios usuario)
        {
            await Coleccion.InsertOneAsync(usuario);
        }

        public async Task<List<Usuarios>> TomarUsuarios()
        {
            return await Coleccion.FindAsync(new BsonDocument()).Result.ToListAsync();
        }
        
        public async Task<Usuarios> TomarUsuariosId(string id)
        {
            return await Coleccion.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }
    }
}
