using System;
using System.Collections.Generic;
using Ativ4Mongo.backend.Domain;

namespace Ativ4Mongo.backend.Api.ViewModels
{
    public class PostDetailsViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public List<PostSection> Sections { get; set; }
    }
}