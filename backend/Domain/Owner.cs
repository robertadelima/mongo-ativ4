using System;
using MongoDB.Bson;

namespace Ativ4Mongo.backend.Domain
{
    public class Owner : Entity
    {
        public string name;
        public Credential credentials;

    }
}
