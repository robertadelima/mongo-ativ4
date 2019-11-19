using System.Collections.Generic;

namespace Ativ4Mongo.backend.Api.ViewModels
{
    public class PostSectionViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<PostSectionViewModel> Subsections { get; set; }
    }
}