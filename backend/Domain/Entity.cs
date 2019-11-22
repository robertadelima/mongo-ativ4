
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ativ4Mongo.backend.Domain
{
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; } = ObjectId.GenerateNewId().ToString();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Entity entity)
            {
                return Id.Equals(entity.Id);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(Id);
        }
    }
}
