using System;
using MongoDB.Bson;

namespace Ativ4Mongo.backend.Domain
{
    public class Credential : Entity
    {
        public string username;
        public string password;

    }
}
