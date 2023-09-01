using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Categorias
    {
        [BsonId]
        public ObjectId id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

    }
}
