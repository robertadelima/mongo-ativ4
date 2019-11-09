using System;
using backend.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace backend.Domain
{
    public abstract class Entity 
    {
        public ObjectId id;  
    }
}
