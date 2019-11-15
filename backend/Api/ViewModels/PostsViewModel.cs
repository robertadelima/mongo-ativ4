using System;

namespace Ativ4Mongo.backend.Api.ViewModels
{
    public class PostsViewModel
    {
        public string Title { get; set; }

        public string Owner { get; set; }

        public string LastPostTitle { get; set; }

        public DateTime LastPostPublishDate { get; set; }
    }
}