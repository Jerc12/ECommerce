using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Ventas
    {
        [BsonId]
        public ObjectId id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductoId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string TiendaId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UsuarioId { get; set; }

        public int CantProducto { get; set; }
        public int PrecioTotal { get; set; }
    }
}
