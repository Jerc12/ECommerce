using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Productos
    {
        [BsonId]
        public ObjectId id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoriaId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string TiendaId { get; set; }
    }
}
