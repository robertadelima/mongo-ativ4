using System.Net;
using System.Net.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ativ4Mongo.backend.Api.ViewModels;
using Ativ4Mongo.backend.Domain;
using Ativ4Mongo.backend.Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ativ4Mongo.backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly BlogRepository blogRepository;

        public BlogsController(BlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<BlogPreviewViewModel> Get()
        {
            return blogRepository.GetBlogs()
                .Select(entidade => new BlogPreviewViewModel() {
                    Title = entidade.title,
                    Username = entidade.username,
                    Description = entidade.description,
                } );
        }

        //feito para deixar estrutura pronta
        [HttpGet]
        [Route("{username}")]
        public BlogPreviewViewModel GetBlogByUsername(string username)
        {
            if(!blogRepository.UserExists(username))
            {
                return null; //TO DO
            }

            var blog = blogRepository.GetBlogByUsername(username);
            return new BlogPreviewViewModel() {
                    Title = blog.title,
                    Username = blog.username,
                    Description = blog.description,
                };
        }  

        [HttpPost]
        public IActionResult CreateBlog([FromBody] NewBlogViewModel blogViewModel){
            if(blogViewModel == null)
            {
                return BadRequest();
            }

            if(blogRepository.UserExists(blogViewModel.username))
            {
                return Conflict("User already exists");
            }
            Blog blog = new Blog()
            {
                username = blogViewModel.username,
                password = blogViewModel.password,
                title = blogViewModel.title,
                description = blogViewModel.description,
            };
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
