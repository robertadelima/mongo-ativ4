
using System.Collections.Generic;

namespace Ativ4Mongo.backend.Api.Payloads
{
    public class NewPostPayload
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<NewPostPayload> Subsections { get; set; }
    }
}