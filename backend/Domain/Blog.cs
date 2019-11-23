using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Ativ4Mongo.backend.Domain
{
    public class Blog : Entity
    {
        [BsonElement("owner")]
        public string Owner { get; private set; }
        
        [BsonElement("password")]
        public string Password { get; private set; }

        [BsonElement("title")]
        public string Title { get; private set; }
        
        [BsonElement("description")]
        public string Description { get; private set; }
        
        [BsonElement("posts")]
        public List<Post> Posts { get; private set; }
       
        public Blog(string owner, string password, string title, string description, List<Post> posts)
        {
            Owner = owner;
            Password = password;
            Title = title;
            Description = description;
            Posts = posts ?? new List<Post>();
        }
    }
}
