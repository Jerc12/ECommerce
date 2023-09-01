using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Views
{
    public class ConexionMongoDB
    {
        public MongoClient client;
        public IMongoDatabase db;
        public ConexionMongoDB()
        {
            client = new MongoClient("mongodb://127.0.0.1:27017");
            db = client.GetDatabase("DB_E_Commerce");
        }
    }
}
