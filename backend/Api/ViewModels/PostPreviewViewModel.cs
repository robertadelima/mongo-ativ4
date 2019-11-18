using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ativ4Mongo.backend.Api.ViewModels
{
    public class PostPreviewViewModel
    {
        public string Title { get; set; }
        public string FirstContent { get; set; }
        public DateTime PublishDate { get; set; }

    }
}