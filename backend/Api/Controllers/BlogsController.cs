using System.Collections.Generic;
using System.Linq;
using Ativ4Mongo.backend.Api.ViewModels;
using Ativ4Mongo.backend.Api.Payloads;
using Ativ4Mongo.backend.Domain;
using Ativ4Mongo.backend.Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Ativ4Mongo.backend.Api.Controllers
{
    [ApiController]
    [Route("blogs")]
    public class BlogsController : ControllerBase
    {
        private readonly BlogRepository blogRepository;

        public BlogsController(BlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        [EnableCors]
        [HttpGet]
        [Route("")]
        public IEnumerable<BlogPreviewViewModel> GetBlogs()
        {
            return blogRepository.Get()
                .Select(entidade => new BlogPreviewViewModel() {
                    Title = entidade.Title,
                    Username = entidade.Username,
                    Description = entidade.Description,
                } );
        }
        
        [HttpGet]
        [Route("{username}")]
        public IActionResult GetBlogByUsername(string username)
        {
            if (!blogRepository.ExistsByUsername(username))
            {
                return NotFound(); 
            }

            var blog = blogRepository.GetByUsername(username);
            return new ObjectResult(new BlogDetailsViewModel() {
                Title = blog.Title,
                Username = blog.Username,
                Description = blog.Description,
                Posts = blog.Posts?.Select(p => new PostPreviewViewModel(){
                    Title = p.Title,
                    FirstContent = p.FirstContent,
                    PublishDate = p.PublishDate,
                }).ToList()
            });
        }  

        [HttpPost]
        public IActionResult CreateBlog([FromBody] NewBlogPayload blogPayload)
        {
            if (blogPayload?.Username == null)
            {
                return BadRequest();
            }

            if (blogRepository.ExistsByUsername(blogPayload.Username))
            {
                return Conflict("The provided username is already being used");
            }

            var blog = new Blog(
                blogPayload.Username,
                blogPayload.Password,
                blogPayload.Title,
                blogPayload.Description,
                posts: null
            );

            blogRepository.Add(blog);

            return new OkResult();
        }

        [HttpDelete]
        [Route("{username}")]
        public IActionResult Delete(string username)
        {
            var deleted = blogRepository.DeleteByUsername(username);
            if (deleted)
            {
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }
    }
}
