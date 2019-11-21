
using System.Collections.Generic;

namespace Ativ4Mongo.backend.Api.Payloads
{
    public class PostSectionPayload
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<PostSectionPayload> Subsections { get; set; }
    }
}