using System;

namespace Ativ4Mongo.backend.Domain
{
    public class Post : Entity
    {
        public string title { get; private set; }
        public string firstContent { get; private set; }
        public DateTime publishDate { get; private set; }

        public Post(string title, string firstContent)
        {
            this.title = title;
            this.firstContent = firstContent;
            publishDate = DateTime.Now;
        } 
    }
}
