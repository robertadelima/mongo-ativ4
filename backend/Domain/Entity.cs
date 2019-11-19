using MongoDB.Bson;

namespace Ativ4Mongo.backend.Domain
{
    public abstract class Entity 
    {
        public ObjectId _id { get; private set; }  
    }
}
