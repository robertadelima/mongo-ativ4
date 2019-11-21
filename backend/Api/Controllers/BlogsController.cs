using System.Collections.Generic;
using System.Linq;
using Ativ4Mongo.backend.Api.ViewModels;
using Ativ4Mongo.backend.Api.Payloads;
using Ativ4Mongo.backend.Domain;
using Ativ4Mongo.backend.Infra.Repository;
using Microsoft.AspNetCore.Mvc;

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
            if (blogPayload?.username == null)
            {
                return BadRequest();
            }

            if (blogRepository.ExistsByUsername(blogPayload.username))
            {
                return Conflict("User already exists");
            }

            var blog = new Blog(
                blogPayload.username,
                blogPayload.password,
                blogPayload.title,
                blogPayload.description,
                posts: null
            );

            blogRepository.Add(blog);

            return new OkResult();
        }

        /*[HttpDelete("{id}")]
        public IActionResult Delete(string title){
            var blog = blogRepository.getBlogsByTitle(title);

            if(blog == null){
                return NotFound();
            }
        }*/
    }
}
