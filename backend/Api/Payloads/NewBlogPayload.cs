namespace Ativ4Mongo.backend.Api.Payloads
{
    public class NewBlogPayload
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public string Password { get; set; }

    }
}