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
    public class PostsController : ControllerBase
    {
        private readonly PostRepository postRepository;

        public PostsController(PostRepository postRepository)
        {
            this.postRepository = postRepository;
        } 

        [HttpGet]
        [Route("")]
        public IEnumerable<PostsViewModel> Get()
        {
            return postRepository.getPosts()
                .Select(entidade => new PostsViewModel() {
                    Id = entidade._id,
                    Title = entidade.title,
                    FirstContent = entidade.firstContent,
                } );
        }


        [HttpPost]
        [Route("")]
        public IActionResult CreateBlog([FromBody] PostsViewModel post){
            if(post == null){
                return BadRequest();
            }
            post.publishDate = DateTime.Now;
            postRepository.Add(post);
            return new NoContentResult();
        }


        [HttpDelete]
        [Route("{title}")]
        public IActionResult Delete(string title){
            var post = postRepository.getPostsByTitle(title);

            if(post == null)
                return NotFound();
            
            postRepository.Remove(title);
            return new NoContentResult();
        }



    }
}