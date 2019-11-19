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
        [Route("{username}/[controller]")]
        public IEnumerable<PostPreviewViewModel> Get(string username)
        {
            //TODO 
            //REFACTOR
            return postRepository.getPosts()
                .Select(entidade => new PostPreviewViewModel() {
                    Title = entidade.title,
                    FirstContent = entidade.firstContent,
                } );
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreatePost([FromBody] PostPreviewViewModel postViewModel){
            
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
        public IActionResult Delete(string title){
            var post = postRepository.getPostsByTitle(title);

            if(post == null)
                return NotFound();
            
            postRepository.Remove(title);
            return new NoContentResult();
        }



    }
}