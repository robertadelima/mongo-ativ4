using System.Collections.Generic;

namespace Ativ4Mongo.backend.Domain
{
    public class Blog : Entity
    {
        public string username { get; private set; }
        public string password { get; private set; }
        public string title { get; private set; }
        public string description { get; private set; }
        public List<Post> posts { get; private set; }
       
        public Blog(string username, string password, string title, string description, List<Post> posts)
        {
            this.username = username;
            this.password = password;
            this.title = title;
            this.description = description;
            this.posts = posts;
        }
    }
}
