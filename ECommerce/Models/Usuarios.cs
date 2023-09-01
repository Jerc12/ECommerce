using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Usuarios
    {
        [BsonId]
        public ObjectId id { get; set; }
        public string Nombre { get; set; }
        public int NumDocumento { get; set; }
        public string Contrasena { get; set; }
    }
}
