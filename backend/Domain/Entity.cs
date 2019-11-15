using System;
using Ativ4Mongo.backend.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ativ4Mongo.backend.Domain
{
    public abstract class Entity 
    {
        public ObjectId id;  
    }
}
