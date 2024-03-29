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
        private readonly PostSectionRepository postSectionRepository;

        public BlogsController(BlogRepository blogRepository, PostSectionRepository postSectionRepository)
        {
            this.blogRepository = blogRepository;
            this.postSectionRepository = postSectionRepository;
        }

        /// <summary>
        /// Returns a collection of registered blogs sorted by their last post's publish date
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Returns the blog's posts sorted by publish date
        /// </summary>
        /// <param name="owner"> Blog's Owner</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a new blog account
        /// </summary>
        /// <param name="blogPayload"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Deletes a blog account
        /// </summary>
        /// <param name="owner"> Blog's Owner </param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{owner}")]
        public IActionResult Delete(string owner)
        {
            var blog = blogRepository.GetByOwner(owner);
            if(blog == null)
            {
                return NoContent();
            }
            foreach (var post in blog.Posts)
            {
                postSectionRepository.DeleteByPostId(post.Id);
            }

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
