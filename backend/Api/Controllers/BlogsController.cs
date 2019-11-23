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
                    Owner = entidade.Owner,
                    Description = entidade.Description,
                } );
        }
        
        [HttpGet]
        [Route("{owner}")]
        public IActionResult GetBlogByOwner(string owner)
        {
            if (!blogRepository.ExistsByOwner(owner))
            {
                return NotFound(); 
            }

            var blog = blogRepository.GetByOwner(owner);
            return new ObjectResult(new BlogDetailsViewModel() {
                Title = blog.Title,
                Owner = blog.Owner,
                Description = blog.Description,
                Posts = blog.Posts?.Select(post => new PostPreviewViewModel(){
                    Title = post.Title,
                    FirstContent = post.FirstContent,
                    PublishDate = post.PublishDate,
                }).Reverse()
                .ToList()
            });
        }  

        [HttpPost]
        [Route("")]
        public IActionResult CreateBlog([FromBody] NewBlogPayload blogPayload)
        {
            if (blogPayload?.Owner == null)
            {
                return BadRequest();
            }

            if (blogRepository.ExistsByOwner(blogPayload.Owner))
            {
                return Conflict("The provided owner is already being used");
            }

            var blog = new Blog(
                blogPayload.Owner,
                blogPayload.Password,
                blogPayload.Title,
                blogPayload.Description,
                posts: null
            );

            blogRepository.Add(blog);

            return new OkResult();
        }

        [HttpDelete]
        [Route("{owner}")]
        public IActionResult Delete(string owner)
        {
            var deleted = blogRepository.DeleteByOwner(owner);
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
