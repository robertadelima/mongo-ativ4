using System.Collections.Generic;

namespace Ativ4Mongo.backend.Api.ViewModels
{
    public class BlogDetailsViewModel
    {
        public string Title { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public List<PostPreviewViewModel> Posts { get; set; }
    }
}