using Ativ4Mongo.backend.Api.ViewModels;
using Ativ4Mongo.backend.Domain;
using Ativ4Mongo.backend.Infra.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Ativ4Mongo.backend.Api.Controllers
{
    [ApiController]
    [Route("blogs/{username}")]
    public class PostsController : ControllerBase
    {
        private readonly PostRepository postRepository;

        public PostsController(PostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreatePost([FromBody] PostPreviewViewModel postViewModel)
        {
            if (postViewModel == null)
            {
                return BadRequest();
            }

            var post = new Post(
                postViewModel.Title,
                postViewModel.FirstContent
            );
            postRepository.Add(post);

            return new NoContentResult();
        }

        [HttpDelete]
        [Route("{title}")]
        public IActionResult Delete(string title)
        {
            var post = postRepository.GetByTitle(title);
            if (post == null)
            {
                return NotFound();
            }
            
            postRepository.Remove(title);

            return new NoContentResult();
        }
    }
}